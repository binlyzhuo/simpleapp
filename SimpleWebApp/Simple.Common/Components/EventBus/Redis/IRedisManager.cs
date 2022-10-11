using Simple.Common.Components.EventBus.Abstract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Redis
{
    public interface IRedisManager
    {
        IConnectionMultiplexer Connection { get; }

        ISubscriber Subscriber { get; }

        void StartSubscribe();

        Task PublishAsync<TEvent>(TEvent @event, CancellationToken token = default)
            where TEvent : class, IEventModel;
    }

}
