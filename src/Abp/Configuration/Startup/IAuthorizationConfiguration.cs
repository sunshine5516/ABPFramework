using Abp.Authorization;
using Abp.Collections;

namespace Abp.Configuration.Startup
{
    /// <summary>
    /// 用于配置授权系统
    /// </summary>
    public interface IAuthorizationConfiguration
    {
        /// <summary>
        /// 授权提供列表。
        /// </summary>
        ITypeList<AuthorizationProvider> Providers { get; }

        /// <summary>
        /// Enables/Disables attribute based authentication and authorization.
        /// Default: true.
        /// </summary>
        bool IsEnabled { get; set; }
    }
}