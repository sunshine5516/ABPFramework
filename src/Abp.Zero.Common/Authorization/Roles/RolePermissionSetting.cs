namespace Abp.Authorization.Roles
{
    /// <summary>
    /// 用于存储角色权限设置。
    /// </summary>
    public class RolePermissionSetting : PermissionSetting
    {
        /// <summary>
        /// Role id.
        /// </summary>
        public virtual int RoleId { get; set; }
    }
}