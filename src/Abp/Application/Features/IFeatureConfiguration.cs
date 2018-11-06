using Abp.Collections;

namespace Abp.Application.Features
{
    /// <summary>
    /// 用于配置Feature系统。
    /// </summary>
    public interface IFeatureConfiguration
    {
        /// <summary>
        /// Used to add/remove <see cref="FeatureProvider"/>s.
        /// </summary>
        ITypeList<FeatureProvider> Providers { get; }
    }
}