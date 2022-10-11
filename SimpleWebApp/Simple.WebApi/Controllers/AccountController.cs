using Microsoft.AspNetCore.Mvc;
using Simple.Common.Filters;
using Simple.Common.Result;
using Simple.Services.Account;
using Simple.Services.Account.Models;

namespace Simple.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [DisabledRequestRecord]
    public class AccountController : ControllerBase
    {
        private AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            this._accountService= accountService;
        }

        [HttpPost]
        public async Task<AppResult> Login([FromBody] LoginModel login)
        {
            var token = await _accountService.GetTokenAsync(login);
            return AppResult.Status200OK("成功", "");
        }
    }
}
