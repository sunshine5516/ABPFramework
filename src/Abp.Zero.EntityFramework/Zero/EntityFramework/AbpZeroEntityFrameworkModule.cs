using System.Reflection;
using Abp.Domain.Uow;
using Abp.EntityFramework;
using Abp.Modules;
using Abp.MultiTenancy;
using Castle.MicroKernel.Registration;

namespace Abp.Zero.EntityFramework
{
    /// <summary>
    /// ASP.NET Boilerplate Zero的实体框架集成模块。
    /// </summary>
    [DependsOn(typeof(AbpZeroCoreModule), typeof(AbpEntityFrameworkModule))]
    public class AbpZeroEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.ReplaceService(typeof(IConnectionStringResolver), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IConnectionStringResolver, IDbPerTenantConnectionStringResolver>()
                        .ImplementedBy<DbPerTenantConnectionStringResolver>()
                        .LifestyleTransient()
                    );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
