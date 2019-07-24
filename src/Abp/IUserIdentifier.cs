namespace Abp
{
    /// <summary>
    /// 用户标识接口.
    /// </summary>
    public interface IUserIdentifier
    {
        /// <summary>
        /// 租户Id.
        /// </summary>
        int? TenantId { get; }

        /// <summary>
        /// 用户ID.
        /// </summary>
        long UserId { get; }
    }
}