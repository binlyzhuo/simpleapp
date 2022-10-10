using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Services
{
    public interface ISimpleService
    {
        IServiceProvider ServiceProvider { get; }

        HttpContext HttpContext { get; }

        TService GetService<TService>() where TService : class;

        object GetService(Type type);
    }
}
