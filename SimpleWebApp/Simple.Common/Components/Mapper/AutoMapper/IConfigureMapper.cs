using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Components.Mapper.AutoMapper
{
    public interface IConfigureMapper
    {
        /// <summary>
        /// 配置 AutoMapper
        /// </summary>
        /// <param name="profile"></param>
        void ConfigureMapper(Profile profile);
    }

}
