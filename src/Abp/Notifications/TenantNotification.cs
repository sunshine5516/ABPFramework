using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Abp.Notifications
{
    /// <summary>
    /// 表示租户/用户的已发布通知。
    /// </summary>
    [Serializable]
    public class TenantNotification : EntityDto<Guid>, IHasCreationTime
    {
        /// <summary>
        /// Tenant Id.
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 唯一名称.
        /// </summary>
        public string NotificationName { get; set; }

        /// <summary>
        /// 通知数据.
        /// </summary>
        public NotificationData Data { get; set; }

        /// <summary>
        /// 试题类型.
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// 实体类型名称.
        /// </summary>
        public string EntityTypeName { get; set; }

        /// <summary>
        /// Entity id.
        /// </summary>
        public object EntityId { get; set; }

        /// <summary>
        /// 等级.
        /// </summary>
        public NotificationSeverity Severity { get; set; }

        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TenantNotification()
        {
            CreationTime = Clock.Now;
        }
    }
}