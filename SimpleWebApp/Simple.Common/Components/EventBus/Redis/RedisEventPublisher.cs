using Simple.Common.Components.EventBus.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Redis
{
    public class RedisEventPublisher : IEventPublisher
    {
        private readonly IRedisManager _redisManager;

        public RedisEventPublisher(IRedisManager redisManager)
        {
            _redisManager = redisManager;
        }

        public Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : class, IEventModel
        {
            return _redisManager.PublishAsync(@event);
        }
    }

}
