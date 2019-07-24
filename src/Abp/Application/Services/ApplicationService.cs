using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Features;
using Abp.Authorization;
using Abp.Runtime.Session;
namespace Abp.Application.Services
{
    /// <summary>
    /// 所有其他appservice的基类
    /// 其封装了对AbpSession, Permission和Feature这些模块的功能调用.
    /// </summary>
    public abstract class ApplicationService : AbpServiceBase, IApplicationService, IAvoidDuplicateCrossCuttingConcerns
    {
        #region 声明实例
        public static string[] CommonPostfixes = { "AppService", "ApplicationService" };

        /// <summary>
        /// 获取当前session信息
        /// </summary>
        public IAbpSession AbpSession { get; set; }

        /// <summary>
        /// 权限管理
        /// </summary>
        public IPermissionManager PermissionManager { protected get; set; }

        /// <summary>
        /// Reference to the permission checker.
        /// </summary>
        public IPermissionChecker PermissionChecker { protected get; set; }

        /// <summary>
        /// Reference to the feature manager.
        /// </summary>
        public IFeatureManager FeatureManager { protected get; set; }

        /// <summary>
        /// Reference to the feature checker.
        /// </summary>
        public IFeatureChecker FeatureChecker { protected get; set; }

        /// <summary>
        /// 获取应用的横切关注点。
        /// </summary>
        public List<string> AppliedCrossCuttingConcerns { get; } = new List<string>();

        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数.
        /// </summary>
        protected ApplicationService()
        {
            AbpSession = NullAbpSession.Instance;
            PermissionChecker = NullPermissionChecker.Instance;
        }
        #endregion

        #region 方法
        /// <summary>
        /// Checks if current user is granted for a permission.
        /// </summary>
        /// <param name="permissionName">Name of the permission</param>
        protected virtual Task<bool> IsGrantedAsync(string permissionName)
        {
            return PermissionChecker.IsGrantedAsync(permissionName);
        }

        /// <summary>
        /// Checks if current user is granted for a permission.
        /// </summary>
        /// <param name="permissionName">Name of the permission</param>
        protected virtual bool IsGranted(string permissionName)
        {
            return PermissionChecker.IsGranted(permissionName);
        }

        /// <summary>
        /// Checks if given feature is enabled for current tenant.
        /// </summary>
        /// <param name="featureName">Name of the feature</param>
        /// <returns></returns>
        protected virtual Task<bool> IsEnabledAsync(string featureName)
        {
            return FeatureChecker.IsEnabledAsync(featureName);
        }

        /// <summary>
        /// Checks if given feature is enabled for current tenant.
        /// </summary>
        /// <param name="featureName">Name of the feature</param>
        /// <returns></returns>
        protected virtual bool IsEnabled(string featureName)
        {
            return FeatureChecker.IsEnabled(featureName);
        }
        #endregion

    }
}
