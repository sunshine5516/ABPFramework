﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Json;

namespace Abp.Notifications
{
    /// <summary>
    /// 用于存储通知订阅。
    /// </summary>
    [Table("AbpNotificationSubscriptions")]
    public class NotificationSubscriptionInfo : CreationAuditedEntity<Guid>, IMayHaveTenant
    {
        /// <summary>
        /// 订阅者的租户ID.
        /// </summary>
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// 用户ID.
        /// </summary>
        public virtual long UserId { get; set; }

        /// <summary>
        /// 通知的唯一名称.
        /// </summary>
        [MaxLength(NotificationInfo.MaxNotificationNameLength)]
        public virtual string NotificationName { get; set; }

        /// <summary>
        /// 获取/设置实体类型名称（如果这是实体级别通知）
        /// </summary>
        [MaxLength(NotificationInfo.MaxEntityTypeNameLength)]
        public virtual string EntityTypeName { get; set; }

        /// <summary>
        /// AssemblyQualifiedName of the entity type.
        /// </summary>
        [MaxLength(NotificationInfo.MaxEntityTypeAssemblyQualifiedNameLength)]
        public virtual string EntityTypeAssemblyQualifiedName { get; set; }

        /// <summary>
        /// ID.
        /// </summary>
        [MaxLength(NotificationInfo.MaxEntityIdLength)]
        public virtual string EntityId { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public NotificationSubscriptionInfo()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public NotificationSubscriptionInfo(Guid id, int? tenantId, long userId, string notificationName, EntityIdentifier entityIdentifier = null)
        {
            Id = id;
            TenantId = tenantId;
            NotificationName = notificationName;
            UserId = userId;
            EntityTypeName = entityIdentifier == null ? null : entityIdentifier.Type.FullName;
            EntityTypeAssemblyQualifiedName = entityIdentifier == null ? null : entityIdentifier.Type.AssemblyQualifiedName;
            EntityId = entityIdentifier == null ? null : entityIdentifier.Id.ToJsonString();
        }
    }
}