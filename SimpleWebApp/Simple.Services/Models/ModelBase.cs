using AutoMapper;
using Simple.Common.Components.Mapper.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Services.Models
{
    public abstract class ModelBase : IConfigureMapper
    {
        public virtual void ConfigureMapper(Profile profile)
        {
        }
    }

}
