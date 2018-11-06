using System.Threading.Tasks;
using Abp.Application.Services;
using AbpDemo.Sessions.Dto;

namespace AbpDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
