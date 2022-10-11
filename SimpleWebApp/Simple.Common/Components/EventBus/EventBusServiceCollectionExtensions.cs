using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Simple.Common.Components.EventBus.Abstract;
using Simple.Common.Components.EventBus.Core;
using Simple.Common.Components.EventBus.Local;
using Simple.Common.Components.EventBus.RabbitMq;
using Simple.Common.Components.EventBus.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus
{
    public static partial class EventBusServiceCollectionExtensions
    {
        private static EventBusBuilder AddEventBusCore(this IServiceCollection services)
        {
            // 构建 EventBusBuilder
            SubscriberDictionary subscribers = new SubscriberDictionary();
            EventBusBuilder builder = new EventBusBuilder(services, subscribers);

            // 将 SubscriberDictionary 注为单例
            services.AddSingleton<SubscriberDictionary>(subscribers);

            // 注入基本服务
            services.AddSingleton<ISubscribeManager, SubscribeManager>();

            return builder;
        }

        internal static IServiceCollection AddEventBusDefault(this IServiceCollection services)
        {
            services.AddSingleton<IEventPublisher, DefaultEventPublisher>();

            return services;
        }

        public static EventBusBuilder AddEventBusLocal(this IServiceCollection services, Action<LocalEventBusOptions>? setupAction = null)
        {
            // 替换 IEventPublisher 实现
            services.Replace(new ServiceDescriptor(typeof(IEventPublisher), typeof(LocalEventPublisher), ServiceLifetime.Singleton));

            services.AddHostedService<LocalEventBusHostedService>();
            services.AddSingleton<IEventStore, ChannelEventStore>();

            // 自定义 EventBusOptions 配置
            if (setupAction != null) services.Configure(setupAction);

            return AddEventBusCore(services);
        }

        public static EventBusBuilder AddEventBusRabbitMq(this IServiceCollection services, Action<RabbitMqEventBusOptions>? setupAction = null)
        {
            // 注入默认连接工厂
            services.AddSingleton<IConnectionFactory>(sp =>
            {
                var options = sp.GetService<IOptions<RabbitMqEventBusOptions>>()?.Value;
                var connectionFactory = new ConnectionFactory();

                if (!string.IsNullOrEmpty(options?.HostName)) connectionFactory.HostName = options.HostName;
                if (options?.Port != null) connectionFactory.Port = options.Port;
                if (!string.IsNullOrEmpty(options?.UserName)) connectionFactory.UserName = options.UserName;
                if (!string.IsNullOrEmpty(options?.Password)) connectionFactory.Password = options.Password;
                if (!string.IsNullOrEmpty(options?.VirtualHost)) connectionFactory.Password = options.VirtualHost;

                return connectionFactory;
            });

            // 替换 IEventPublisher 实现
            services.Replace(new ServiceDescriptor(typeof(IEventPublisher), typeof(RabbitMqEventPublisher), ServiceLifetime.Singleton));

            // 基本服务
            services.AddHostedService<RabbitMqEventBusHostedService>();
            services.AddSingleton<IRabbitMqManager, RabbitMqManager>();

            // 自定义配置
            if (setupAction != null) services.Configure(setupAction);

            return AddEventBusCore(services);
        }

        public static EventBusBuilder AddEventBusRedis(this IServiceCollection services, Action<RedisEventBusOptions>? setupAction = null)
        {
            // 替换 IEventPublisher 实现
            services.Replace(new ServiceDescriptor(typeof(IEventPublisher), typeof(RedisEventPublisher), ServiceLifetime.Singleton));

            // 基本服务
            services.AddHostedService<RedisEventBusHostedService>();
            services.AddSingleton<IRedisManager, RedisManager>();

            // 自定义配置
            if (setupAction != null) services.Configure(setupAction);

            return AddEventBusCore(services);
        }
    }

}
