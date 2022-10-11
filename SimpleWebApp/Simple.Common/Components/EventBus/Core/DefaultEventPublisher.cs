﻿using Simple.Common.Components.EventBus.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Core
{
    /// <summary>
    /// 事件总线发布者默认实现
    /// </summary>
    public class DefaultEventPublisher : IEventPublisher
    {
        public virtual Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : class, IEventModel
        {
            return Task.CompletedTask;
        }
    }

}
