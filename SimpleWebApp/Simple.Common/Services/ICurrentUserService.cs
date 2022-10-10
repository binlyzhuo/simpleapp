using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Common.Services
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal User { get; }
        bool IsAuthenticated { get; }
        Guid? UserId { get; }
        string? UserName { get; }
        string[] Roles { get; }
        string? Name { get; }
        string? Email { get; }
        Guid? TenantId { get; }
        bool IsSuperAdmin { get; }

        bool IsInRole(string roleName);
        Claim? FindClaim(string claimType);
        Claim[] FindClaims(string claimType);
        string? FindClaimValue(string claimType);
    }
}
