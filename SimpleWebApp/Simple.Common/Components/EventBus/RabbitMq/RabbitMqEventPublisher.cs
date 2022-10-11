using Simple.Common.Components.EventBus.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.RabbitMq
{
    public class RabbitMqEventPublisher : IEventPublisher
    {
        private readonly IRabbitMqManager _rabbitMqManager;

        public RabbitMqEventPublisher(IRabbitMqManager rabbitMqManager)
        {
            _rabbitMqManager = rabbitMqManager;
        }

        public Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : class, IEventModel
        {
            return _rabbitMqManager.PublishAsync(@event);
        }
    }


}
