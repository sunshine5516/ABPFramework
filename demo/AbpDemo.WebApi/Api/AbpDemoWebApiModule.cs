using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Web;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using AbpDemo.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AbpDemo.WebApi.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(AbpDemoApplicationModule))]
    public class AbpDemoWebApiModule: AbpModule
    {
        public override void Initialize()
        {

            //var t = IocManager.Resolve<IDynamicApiControllerBuilder>();

            //t.For<ITaskAppService>("DepartAndNavi/NaviTree").ForMethod("GetAllTasks").WithVerb(HttpVerb.Get).Build();

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(AbpDemoApplicationModule).Assembly, "app")
                .Build();
            //Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder.For<ITaskAppService>("tasksystem/task").Build();
            Configuration.Modules.AbpWebApi().HttpConfiguration.
                Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
