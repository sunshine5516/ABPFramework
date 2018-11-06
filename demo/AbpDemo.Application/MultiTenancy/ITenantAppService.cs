using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpDemo.MultiTenancy.Dto;

namespace AbpDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
