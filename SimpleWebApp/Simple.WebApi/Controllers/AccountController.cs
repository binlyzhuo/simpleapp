using Microsoft.AspNetCore.Mvc;
using Simple.Common.Filters;

namespace Simple.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [DisabledRequestRecord]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {

        }
    }
}
