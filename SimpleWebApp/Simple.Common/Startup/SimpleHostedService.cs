using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Simple.Common.Components.Json;
using Simple.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Startup
{
    public class SimpleHostedService: IHostedService
    {
        public IHost Host { set; get; }

        public SimpleHostedService(IHost host)
        {
            Host = host;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var serviceProvider = Host.Services;
            ServiceHelper.Configure(serviceProvider);

            var jsonOptions = serviceProvider.GetService<IOptions<JsonOptions>>();
            if (jsonOptions != null) JsonHelper.Configure(jsonOptions!.Value.JsonSerializerOptions);



            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
