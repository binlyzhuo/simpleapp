using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Filters
{
    /// <summary>
    /// 禁用请求记录过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DisabledRequestRecordAttribute : Attribute
    {

    }
}
