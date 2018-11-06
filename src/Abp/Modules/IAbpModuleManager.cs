using System;
using System.Collections.Generic;

namespace Abp.Modules
{
    /// <summary>
    /// 模块管理接口
    /// </summary>
    public interface IAbpModuleManager
    {
        AbpModuleInfo StartupModule { get; }

        IReadOnlyList<AbpModuleInfo> Modules { get; }

        void Initialize(Type startupModule);

        void StartModules();

        void ShutdownModules();
    }
}