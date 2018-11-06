using System.Reflection;

namespace Abp.Dependency
{
    /// <summary>   
    ///传统的注册过程中传递需要的对象。
    ///这里主要封装了Assembly，IocManager和ConventionalRegistrationConfig
    /// </summary>
    public interface IConventionalRegistrationContext
    {
        /// <summary>
        /// 要注册的程序集
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// IIocManager容器
        /// </summary>
        IIocManager IocManager { get; }

        /// <summary>
        /// 注册的配置
        /// </summary>
        ConventionalRegistrationConfig Config { get; }
    }
}