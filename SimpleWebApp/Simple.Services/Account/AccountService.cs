using Simple.Common.Services;
using Simple.Repository.Data;
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

        public AccountService()
        {

        }
    }
}
