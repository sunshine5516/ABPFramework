using System.Reflection;

namespace Abp.Dependency
{
    /// <summary>
    ///传统的注册过程中传递需要的对象。
    ///这里主要封装了Assembly，IocManager和ConventionalRegistrationConfig
    /// </summary>
    internal class ConventionalRegistrationContext : IConventionalRegistrationContext
    {
        /// <summary>
        /// 注册的程序集
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// IIocManager容器
        /// </summary>
        public IIocManager IocManager { get; private set; }

        /// <summary>
        /// 注册配置
        /// </summary>
        public ConventionalRegistrationConfig Config { get; private set; }

        internal ConventionalRegistrationContext(Assembly assembly, IIocManager iocManager, ConventionalRegistrationConfig config)
        {
            Assembly = assembly;
            IocManager = iocManager;
            Config = config;
        }
    }
}