using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Simple.Common.Components.EventBus.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Redis
{
    public class RedisEventBusHostedService : IHostedService
    {
        private readonly ILogger<RedisEventBusHostedService> _logger;
        private readonly IRedisManager _redisManager;
        public RedisEventBusHostedService(ILogger<RedisEventBusHostedService> logger,
                                          IRedisManager redisManager)
        {
            _logger = logger;
            _redisManager = redisManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RabbitMqEventBusHostedService)} is running.");

            // 启动订阅
            _redisManager.StartSubscribe();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RabbitMqEventBusHostedService)} is stopping.");

            return Task.CompletedTask;
        }
    }

}
