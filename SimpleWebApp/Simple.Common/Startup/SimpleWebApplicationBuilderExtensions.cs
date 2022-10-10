using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using Simple.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Startup
{
    public static class SimpleWebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder SimpleConfigure(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            AppSettingsConfig.Configure(configuration);

            builder.Host.UseNLog();
            builder.Services.AddHostedService<SimpleHostedService>();
            //builder.Services.AddEventBusDefault();
            return builder;
        }
    }
}
