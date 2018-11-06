using System.Collections.Generic;
using Abp.MultiTenancy;

namespace Abp.Authorization
{
    /// <summary>
    /// 权限管理接口
    /// </summary>
    public interface IPermissionManager
    {
        /// <summary>
        /// 根据名称获取 <see cref="Permission"/>权限
        /// </summary>
        /// <param name="name"></param>
        Permission GetPermission(string name);

        /// <summary>
        /// 根据名称获取 <see cref="Permission"/>权限或者返回空        
        /// </summary>
        /// <param name="name"></param>
        Permission GetPermissionOrNull(string name);

        /// <summary>
        /// 获取所有权限.
        /// </summary>
        /// <param name="tenancyFilter">Can be passed false to disable tenancy filter.</param>
        IReadOnlyList<Permission> GetAllPermissions(bool tenancyFilter = true);

        /// <summary>
        /// Gets all permissions.
        /// </summary>
        /// <param name="multiTenancySides">Multi-tenancy side to filter</param>
        IReadOnlyList<Permission> GetAllPermissions(MultiTenancySides multiTenancySides);
    }
}
