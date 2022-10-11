using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Abstract
{
    /// <summary>
    /// 事件模型接口
    /// </summary>
    public interface IEventModel
    {
        Guid Id { get; }

        DateTimeOffset UtcNow { get; }
    }
}
