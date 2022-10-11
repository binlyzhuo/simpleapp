using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Extensions
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// 获取完整请求地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetRequestUrlAddress(this HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.Scheme).Append("://").Append(request.Host)
                .Append(request.PathBase.ToString())
                .Append(request.Path.ToString())
                .Append(request.QueryString)
                .ToString();
        }
    }

}
