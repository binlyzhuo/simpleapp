using Simple.Common.Services;
using Simple.Repository.Data;
using Simple.Services.Account.Models;
using Simple.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Services.Account
{
    public class AccountService
    {
        private readonly SimpleDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly CacheService _cacheService;

        public AccountService(SimpleDbContext context, ICurrentUserService currentUser, CacheService cacheService)
        {
            this._context = context;
            this._currentUser = currentUser;
            this._cacheService = cacheService;
        }

        /// <summary>
        /// 获取 JwtToken
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<string> GetTokenAsync(LoginModel login)
        {
            return await Task.Run(() => "455");
        }
    }
}
