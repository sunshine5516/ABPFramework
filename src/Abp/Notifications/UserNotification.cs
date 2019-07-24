using System;
using Abp.Application.Services.Dto;

namespace Abp.Notifications
{
    /// <summary>
    /// 用于封装User和Notification关系的Entity.
    /// </summary>
    [Serializable]
    public class UserNotification : EntityDto<Guid>, IUserIdentifier
    {
        /// <summary>
        /// TenantId.
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// User Id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 当前通知状态.
        /// </summary>
        public UserNotificationState State { get; set; }

        /// <summary>
        /// The notification.
        /// </summary>
        public TenantNotification Notification { get; set; }
    }
}