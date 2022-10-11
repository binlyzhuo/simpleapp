using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.EventBus.Local
{
    public class LocalEventBusOptions
    {
        /// <summary>
        /// 队列容量
        /// </summary>
        public int Capacity { get; set; } = 2048;
    }
}
