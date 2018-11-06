using Abp.Collections;

namespace Abp.Configuration.Startup
{
    /// <summary>
    /// 用于集中化设置和管理SettingProvider的对象。
    /// </summary>
    public interface ISettingsConfiguration
    {
        /// <summary>
        /// List of settings providers.
        /// </summary>
        ITypeList<SettingProvider> Providers { get; }
    }
}
