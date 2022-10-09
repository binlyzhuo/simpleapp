using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Configuration
{
    public static class AppSettingsConfig
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
    }
}
