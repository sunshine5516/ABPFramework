using Abp.Configuration;
using Castle.DynamicProxy;

namespace Abp.Dependency
{
    /// <summary>
    /// 类用于以传统方式注册类时传递配置/选项。
    /// </summary>
    public class ConventionalRegistrationConfig : DictionaryBasedConfig
    {
        /// <summary>
        /// 是否注册所有的<see cref ="IInterceptor"/>实现。
        /// 默认: true. 
        /// </summary>
        public bool InstallInstallers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConventionalRegistrationConfig()
        {
            InstallInstallers = true;
        }
    }
}