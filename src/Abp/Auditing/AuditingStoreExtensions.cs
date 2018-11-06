using Abp.Threading;

namespace Abp.Auditing
{
    /// <summary>
    /// <see cref="IAuditingStore"/>扩展方法
    /// </summary>
    public static class AuditingStoreExtensions
    {
        /// <summary>
        /// 审核保存到持久性存储中.
        /// </summary>
        /// <param name="auditingStore">Auditing store</param>
        /// <param name="auditInfo">审计信息</param>
        public static void Save(this IAuditingStore auditingStore, AuditInfo auditInfo)
        {
            AsyncHelper.RunSync(() => auditingStore.SaveAsync(auditInfo));
        }
    }
}