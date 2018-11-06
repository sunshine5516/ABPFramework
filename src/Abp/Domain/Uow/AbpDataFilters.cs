using Abp.Domain.Entities;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// Standard filters of ABP.
    /// </summary>
    public static class AbpDataFilters
    {
        /// <summary>
        /// "SoftDelete".
        /// 软删除过滤器.
        /// 不获取“deleted”的数据
        /// See <see cref="ISoftDelete"/> interface.
        /// </summary>
        public const string SoftDelete = "SoftDelete";

        /// <summary>
        /// 租户过滤器.
        /// 租户过滤器不获取不属于当前的租户
        /// </summary>
        public const string MustHaveTenant = "MustHaveTenant";

        /// <summary>
        /// 租户过滤器.
        /// 租户过滤器不获取不属于当前的租户
        /// </summary>
        public const string MayHaveTenant = "MayHaveTenant";

        /// <summary>
        /// 参数.
        /// </summary>
        public static class Parameters
        {
            /// <summary>
            /// "tenantId".
            /// </summary>
            public const string TenantId = "tenantId";
        }
    }
}