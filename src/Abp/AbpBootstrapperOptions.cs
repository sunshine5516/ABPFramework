using Abp.Dependency;
using Abp.PlugIns;

namespace Abp
{
    public class AbpBootstrapperOptions
    {
        /// <summary>
        /// 禁用ABP添加的所有拦截器.
        /// </summary>
        public bool DisableAllInterceptors { get; set; }

        /// <summary>
        /// IIocManager用于引导ABP系统。 如果设置为null，则使用全局<see cref ="Abp.Dependency.IocManager.Instance"/>
        /// </summary>
        public IIocManager IocManager { get; set; }

        /// <summary>
        /// List of plugin sources.
        /// </summary>
        public PlugInSourceList PlugInSources { get; }

        public AbpBootstrapperOptions()
        {
            IocManager = Abp.Dependency.IocManager.Instance;
            PlugInSources = new PlugInSourceList();
        }
    }
}
