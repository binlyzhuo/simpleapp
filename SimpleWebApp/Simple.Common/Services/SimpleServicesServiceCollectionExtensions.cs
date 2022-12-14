using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Services
{
    public static class SimpleServicesServiceCollectionExtensions
    {
        /// <summary>
        /// 注册基础服务（当前用户等）
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSimpleBaseServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ISimpleService, SimpleService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
