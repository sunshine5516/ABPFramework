using System.Collections;
using Abp.Collections;
using Abp.MultiTenancy;

namespace Abp.Configuration.Startup
{
    /// <summary>
    /// 多租户配置.
    /// </summary>
    public interface IMultiTenancyConfig
    {
        /// <summary>
        /// 是否可用；默认false
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// A list of contributors for tenant resolve process.
        /// </summary>
        ITypeList<ITenantResolveContributor> Resolvers { get; }
    }
}