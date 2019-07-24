using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// 用户的权限检测接口。
    /// </summary>
    public interface IPermissionChecker
    {
        /// <summary>
        /// 检查当前用户是否被授予权限。
        /// </summary>
        /// <param name="permissionName">权限名称</param>
        Task<bool> IsGrantedAsync(string permissionName);

        /// <summary>
        /// 检查当前用户是否被授予权限。
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="permissionName">权限名称</param>
        Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName);
    }
}