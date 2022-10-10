using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Result
{
    public class AppResultOptions
    {
        private Func<AppResultException, IActionResult> _resultFactory = default!;

        public Func<AppResultException, IActionResult> ResultFactory
        {
            get => _resultFactory;
            set => _resultFactory = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
