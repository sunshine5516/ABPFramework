namespace Abp.Authorization.Users
{
    /// <summary>
    /// 用于存储用户权限的设置。
    /// </summary>
    public class UserPermissionSetting : PermissionSetting
    {
        /// <summary>
        /// User id.
        /// </summary>
        public virtual long UserId { get; set; }
    }
}