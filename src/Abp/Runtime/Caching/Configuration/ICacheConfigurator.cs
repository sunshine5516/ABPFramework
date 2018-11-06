using System;

namespace Abp.Runtime.Caching.Configuration
{
    /// <summary>
    ///已注册的缓存配置器接口
    /// </summary>
    public interface ICacheConfigurator
    {
        /// <summary>
        /// 缓存名称
        /// 如果此配置程序配置所有缓存，它将为空。
        /// </summary>
        string CacheName { get; }

        /// <summary>
        /// 配置操作。 在创建缓存之后调用。
        /// </summary>
        Action<ICache> InitAction { get; }
    }
}