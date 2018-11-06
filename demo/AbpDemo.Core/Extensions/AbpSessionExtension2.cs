using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AbpDemo.Extensions
{
    public static class AbpSessionExtension2
    {
        public static string GetUserEmail(this IAbpSession session)
        {
            return GetClaimValue(ClaimTypes.Email);
        }
        private static string GetClaimValue(string claimType)
        {
            var claimsPrincipal = DefaultPrincipalAccessor.Instance.Principal;
            var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == claimType);
            if (string.IsNullOrEmpty(claim.Value))
            {
                return null;
            }
            return claim.Value;
        }
    }
}
