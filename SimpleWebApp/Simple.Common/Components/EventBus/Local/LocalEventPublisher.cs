using Simple.Common.Components.EventBus.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Local
{
    public class LocalEventPublisher : IEventPublisher
    {
        private readonly IEventStore _eventStore;

        public LocalEventPublisher(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public virtual async Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : class, IEventModel
        {
            await _eventStore.WriteAsync<TEvent>(@event);
        }
    }

}
