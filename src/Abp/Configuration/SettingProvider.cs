using System.Collections.Generic;
using Abp.Dependency;

namespace Abp.Configuration
{
    /// <summary>
    /// 定义模块/应用程序的设置。
    /// </summary>
    public abstract class SettingProvider : ITransientDependency
    {
        /// <summary>
        /// 为具体的功能模块所需的设置定义SettingDefinition,并且以数组的形式返回.
        /// </summary>
        /// <returns>List of settings</returns>
        public abstract IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context);
    }
}