using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Abstract
{
    public interface IEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : class, IEventModel;
    }

}
