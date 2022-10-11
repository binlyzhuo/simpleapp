using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Configuration
{
    public static class AppSettings
    {
        private static IConfiguration? _configuration;

        public static IConfiguration? Configuration
        {
            get
            {
                if (_configuration == null)
                    throw new NullReferenceException(nameof(Configuration));
                return _configuration;

            }
        }

        public static void Configure(IConfiguration? configuration)
        {
            if(_configuration!=null)
            {
                throw new Exception($"{nameof(Configuration)}不可修改！");
            }

            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// 记录请求
        /// </summary>
        public static class RecordRequest
        {
            public static bool IsEnabled => Configuration.GetValue<bool>("RecordRequest:IsEnabled");
            public static bool IsSkipGetMethod => Configuration.GetValue<bool>("RecordRequest:IsSkipGetMethod");
        }


        /// <summary>
        /// Redis 配置
        /// </summary>
        public static class Redis
        {
            public static bool Enabled => Configuration.GetValue<bool>("Redis:Enabled");
            public static string ConnectionString => Configuration["Redis:ConnectionString"];
            public static string Instance => Configuration["Redis:Instance"] ?? "Default";
        }
    }
}
