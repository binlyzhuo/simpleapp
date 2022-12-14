using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.RabbitMq
{
    public class RabbitMqEventBusHostedService : IHostedService
    {
        private readonly ILogger<RabbitMqEventBusHostedService> _logger;
        private readonly IRabbitMqManager _rabbitMqManager;
        public RabbitMqEventBusHostedService(ILogger<RabbitMqEventBusHostedService> logger,
                                             IRabbitMqManager rabbitMqManager)
        {
            _logger = logger;
            _rabbitMqManager = rabbitMqManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RabbitMqEventBusHostedService)} is running.");

            // 启动订阅
            _rabbitMqManager.StartSubscribe();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RabbitMqEventBusHostedService)} is stopping.");

            return Task.CompletedTask;
        }
    }


}
