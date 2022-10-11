using Simple.Common.Components.EventBus.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Local
{
    public interface IEventStore
    {
        ValueTask WriteAsync<TEvent>(TEvent @event)
            where TEvent : class, IEventModel;

        ValueTask<object> ReadAsync(CancellationToken cancellationToken);
    }

}
