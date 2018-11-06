using System.Web.Http;
using Abp.Dependency;
using Castle.MicroKernel.Registration;
using System.Reflection;

namespace Abp.WebApi.Controllers
{
    /// <summary>
    /// 注册所有派生自<see cref ="ApiController"/>的Web API控制器。
    /// </summary>
    public class ApiControllerConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                    .BasedOn<ApiController>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .LifestyleTransient()
                );
        }
    }
}
