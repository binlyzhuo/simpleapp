using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.DataValidation
{
    public static class DataValidationMvcBuilderExtensions
    {
        /// <summary>
        /// 配置模型验证
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddDataValidation(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                // 禁用默认模型验证过滤器
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.AddMvcOptions(options =>
            {
                // 添加自定义模型验证过滤器
                options.Filters.Add<DataValidationFilter>();
            });

            return builder;
        }

        
    }
}
