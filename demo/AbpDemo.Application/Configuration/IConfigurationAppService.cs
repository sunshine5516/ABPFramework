using System.Threading.Tasks;
using Abp.Application.Services;
using AbpDemo.Configuration.Dto;

namespace AbpDemo.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}