using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Helpers
{
    public class ServiceHelper
    {
        private static IServiceProvider? _rootServices;

        public static IServiceProvider RootServices
        {
            get
            {
                if (_rootServices == null) throw new NullReferenceException(nameof(RootServices));
                return _rootServices;
            }
        }

        public static void Configure(IServiceProvider serviceProvider)
        {
            if (_rootServices != null)
            {
                throw new Exception($"{nameof(RootServices)}不可修改！");
            }
            _rootServices = serviceProvider;
        }
    }
}
