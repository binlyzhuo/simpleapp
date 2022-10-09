using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Startup
{
    public static class SimpleWebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder SimpleConfigure(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            return builder;
        }
    }
}
