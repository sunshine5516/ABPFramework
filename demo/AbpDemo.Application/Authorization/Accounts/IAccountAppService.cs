using System.Threading.Tasks;
using Abp.Application.Services;
using AbpDemo.Authorization.Accounts.Dto;

namespace AbpDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
