using System;
using System.Reflection;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Dependency.Installers;
using Abp.Domain.Uow;
using Abp.Modules;
using Abp.PlugIns;
using Abp.Runtime.Validation.Interception;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using JetBrains.Annotations;

namespace Abp
{
    /// <summary>
    /// 负责启动整个ABP系统的主要类。
    /// 准备依赖注入并注册启动所需的核心组件。
    /// 必须首先在应用程序中实例化并初始化（请参阅<请参阅cref="Initialize"/>）。
    /// </summary>
    public class AbpBootstrapper : IDisposable
    {
        #region 声明实例
        /// <summary>
        /// 获取依赖于其他使用模块的应用程序的启动模块。
        /// </summary>
        public Type StartupModule { get; }

        /// <summary>
        /// 文件夹中插件列表
        /// </summary>
        public PlugInSourceList PlugInSources { get; }

        /// <summary>
        /// IIocManager实例
        /// </summary>
        public IIocManager IocManager { get; }

        /// <summary>
        /// Is this object disposed before?
        /// </summary>
        protected bool IsDisposed;

        private AbpModuleManager _moduleManager;
        private ILogger _logger;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="startupModule">依赖于其他使用模块的应用程序的启动模块。AbpModule中派生。</param>
        /// <param name="optionsAction">设置选项的操作</param>
        private AbpBootstrapper([NotNull] Type startupModule, [CanBeNull] Action<AbpBootstrapperOptions> optionsAction = null)
        {
            Check.NotNull(startupModule, nameof(startupModule));

            var options = new AbpBootstrapperOptions();
            optionsAction?.Invoke(options);

            if (!typeof(AbpModule).GetTypeInfo().IsAssignableFrom(startupModule))
            {
                throw new ArgumentException($"{nameof(startupModule)} should be derived from {nameof(AbpModule)}.");
            }

            StartupModule = startupModule;

            IocManager = options.IocManager;
            PlugInSources = options.PlugInSources;

            _logger = NullLogger.Instance;

            if (!options.DisableAllInterceptors)
            {
                AddInterceptorRegistrars();
            }
        }
        #endregion


        /// <summary>
        /// 添加实例
        /// </summary>
        /// <typeparam name="TStartupModule">依赖于其他使用模块的应用程序的启动模块。AbpModule中派生.</typeparam>
        /// <param name="optionsAction">An action to set options</param>
        public static AbpBootstrapper Create<TStartupModule>([CanBeNull] Action<AbpBootstrapperOptions> optionsAction = null)
            where TStartupModule : AbpModule
        {
            return new AbpBootstrapper(typeof(TStartupModule), optionsAction);
        }

        /// <summary>
        /// 添加实例
        /// </summary>
        /// <param name="startupModule">依赖于其他使用模块的应用程序的启动模块。AbpModule中派生.</param>
        /// <param name="optionsAction">An action to set options</param>
        public static AbpBootstrapper Create([NotNull] Type startupModule, [CanBeNull] Action<AbpBootstrapperOptions> optionsAction = null)
        {
            return new AbpBootstrapper(startupModule, optionsAction);
        }

        /// <summary>
        /// 添加实例
        /// </summary>
        /// <typeparam name="TStartupModule">依赖于其他使用模块的应用程序的启动模块。AbpModule中派生.</typeparam>
        /// <param name="iocManager">用于引导ABP系统的IIocManager</param>
        [Obsolete("Use overload with parameter type: Action<AbpBootstrapperOptions> optionsAction")]
        public static AbpBootstrapper Create<TStartupModule>([NotNull] IIocManager iocManager)
            where TStartupModule : AbpModule
        {
            return new AbpBootstrapper(typeof(TStartupModule), options =>
            {
                options.IocManager = iocManager;
            });
        }
        /// <summary>
        /// 添加实例
        /// </summary>
        /// <param name="startupModule">依赖于其他使用模块的应用程序的启动模块.</param>
        /// <param name="iocManager">用于引导ABP系统的IIocManager</param>
        [Obsolete("Use overload with parameter type: Action<AbpBootstrapperOptions> optionsAction")]
        public static AbpBootstrapper Create([NotNull] Type startupModule, [NotNull] IIocManager iocManager)
        {
            return new AbpBootstrapper(startupModule, options =>
            {
                options.IocManager = iocManager;
            });
        }
        /// <summary>
        /// 注册拦截器
        /// </summary>
        private void AddInterceptorRegistrars()
        {
            ValidationInterceptorRegistrar.Initialize(IocManager);
            AuditingInterceptorRegistrar.Initialize(IocManager);
            UnitOfWorkRegistrar.Initialize(IocManager);
            AuthorizationInterceptorRegistrar.Initialize(IocManager);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Initialize()
        {
            ResolveLogger();

            try
            {
                RegisterBootstrapper();
                //AbpCoreInstaller注册的是系统框架级（核心框架，也就是指Abp项目）的所有configuration
                IocManager.IocContainer.Install(new AbpCoreInstaller());

                IocManager.Resolve<AbpPlugInManager>().PlugInSources.AddRange(PlugInSources);
                IocManager.Resolve<AbpStartupConfiguration>().Initialize();

                _moduleManager = IocManager.Resolve<AbpModuleManager>();
                _moduleManager.Initialize(StartupModule);
                _moduleManager.StartModules();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex.ToString(), ex);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().Create(typeof(AbpBootstrapper));
            }
        }

        private void RegisterBootstrapper()
        {
            if (!IocManager.IsRegistered<AbpBootstrapper>())
            {
                IocManager.IocContainer.Register(
                    Component.For<AbpBootstrapper>().Instance(this)
                    );
            }
        }

        /// <summary>
        /// Disposes the ABP system.
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            _moduleManager?.ShutdownModules();
        }
    }
}
