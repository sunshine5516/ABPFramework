using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Authorization.Users
{
    /// <summary>
    /// 为用户执行权限数据库操作。
    /// </summary>
    public interface IUserPermissionStore<in TUser>
        where TUser : AbpUserBase
    {
        /// <summary>
        /// 向用户添加权限授予设置.
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="permissionGrant">Permission grant setting info</param>
        Task AddPermissionAsync(TUser user, PermissionGrantInfo permissionGrant);

        /// <summary>
        /// 删除用户权限授予
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="permissionGrant">Permission grant setting info</param>
        Task RemovePermissionAsync(TUser user, PermissionGrantInfo permissionGrant);

        /// <summary>
        /// 获取用户权限信息
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>List of permission setting informations</returns>
        Task<IList<PermissionGrantInfo>> GetPermissionsAsync(long userId);

        /// <summary>
        /// 检测角色是否有权限
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="permissionGrant">Permission grant setting info</param>
        /// <returns></returns>
        Task<bool> HasPermissionAsync(long userId, PermissionGrantInfo permissionGrant);

        /// <summary>
        /// 删除角色的所有权限
        /// </summary>
        /// <param name="user">User</param>
        Task RemoveAllPermissionSettingsAsync(TUser user);
    }
}