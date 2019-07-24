using System.Threading.Tasks;
using Abp.Auditing;
using Abp.AutoMapper;
using AbpDemo.Sessions.Dto;

namespace AbpDemo.Sessions
{
    public class SessionAppService : ABPMultiMVCAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput();

            if (AbpSession.UserId.HasValue)
            {
                var teme = await GetCurrentUserAsync();
                output.User = (teme).MapTo<UserLoginInfoDto>();
            }

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = (await GetCurrentTenantAsync()).MapTo<TenantLoginInfoDto>();
            }

            return output;
        }
    }
}