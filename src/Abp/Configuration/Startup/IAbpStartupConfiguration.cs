using System;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Abp.Notifications;
using Abp.Resources.Embedded;
using Abp.Runtime.Caching.Configuration;

namespace Abp.Configuration.Startup
{
    /// <summary>
    /// 启动时配置ABP和模块接口
    /// </summary>
    public interface IAbpStartupConfiguration : IDictionaryBasedConfig
    {
        /// <summary>
        /// 注册容器
        /// </summary>
        IIocManager IocManager { get; }

        /// <summary>
        /// 本地化配置
        /// </summary>
        ILocalizationConfiguration Localization { get; }

        /// <summary>
        /// 导航配置.
        /// </summary>
        INavigationConfiguration Navigation { get; }

        /// <summary>
        /// 事件总成配置
        /// </summary>
        IEventBusConfiguration EventBus { get; }

        /// <summary>
        /// 审计配置
        /// </summary>
        IAuditingConfiguration Auditing { get; }

        /// <summary>
        /// 缓存配置
        /// </summary>
        ICachingConfiguration Caching { get; }

        /// <summary>
        /// Used to configure multi-tenancy.
        /// </summary>
        IMultiTenancyConfig MultiTenancy { get; }

        /// <summary>
        /// 权限配置
        /// </summary>
        IAuthorizationConfiguration Authorization { get; }

        /// <summary>
        /// 验证配置
        /// </summary>
        IValidationConfiguration Validation { get; }

        /// <summary>
        /// 设置配置.
        /// </summary>
        ISettingsConfiguration Settings { get; }

        /// <summary>
        /// Gets/sets default connection string used by ORM module.
        /// It can be name of a connection string in application's config file or can be full connection string.
        /// </summary>
        string DefaultNameOrConnectionString { get; set; }

        /// <summary>
        /// 配置模块.
        /// 模块可以将扩展方法写入<see cref ="IModuleConfigurations"/>以添加模块特定的配置。
        /// </summary>
        IModuleConfigurations Modules { get; }

        /// <summary>
        /// UOW默认配置.
        /// </summary>
        IUnitOfWorkDefaultOptions UnitOfWork { get; }

        /// <summary>
        /// Used to configure features.
        /// </summary>
        IFeatureConfiguration Features { get; }

        /// <summary>
        /// 后台工作配置
        /// </summary>
        IBackgroundJobConfiguration BackgroundJobs { get; }

        /// <summary>
        /// 系统通知配置.
        /// </summary>
        INotificationConfiguration Notifications { get; }

        /// <summary>
        /// Used to configure embedded resources.
        /// </summary>
        IEmbeddedResourcesConfiguration EmbeddedResources { get; }

        /// <summary>
        /// Used to replace a service type.
        /// Given <see cref="replaceAction"/> should register an implementation for the <see cref="type"/>.
        /// </summary>
        /// <param name="type">The type to be replaced.</param>
        /// <param name="replaceAction">Replace action.</param>
        void ReplaceService(Type type, Action replaceAction);

        /// <summary>
        /// Gets a configuration object.
        /// </summary>
        T Get<T>();
    }
}