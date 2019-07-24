using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace Abp.Notifications
{
    /// <summary>
    /// 通知订阅管理，用于获取，删除和添加NotificationSubscription
    /// </summary>
    public interface INotificationSubscriptionManager
    {
        /// <summary>
        /// Subscribes to a notification for given user and notification informations.
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="notificationName">Name of the notification.</param>
        /// <param name="entityIdentifier">entity identifier</param>
        Task SubscribeAsync(UserIdentifier user, string notificationName, EntityIdentifier entityIdentifier = null);

        /// <summary>
        /// 订阅给定用户的所有可用通知.
        /// It does not subscribe entity related notifications.
        /// </summary>
        /// <param name="user">User.</param>
        Task SubscribeToAllAvailableNotificationsAsync(UserIdentifier user);

        /// <summary>
        /// 取消订阅通知
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="notificationName">Name of the notification.</param>
        /// <param name="entityIdentifier">entity identifier</param>
        Task UnsubscribeAsync(UserIdentifier user, string notificationName, EntityIdentifier entityIdentifier = null);

        /// <summary>
        /// 获取给定通知的所有订阅（包括所有租户）。
        /// 这仅适用于多租户应用程序中的单一数据库方法!
        /// </summary>
        /// <param name="notificationName">Name of the notification.</param>
        /// <param name="entityIdentifier">entity identifier</param>
        Task<List<NotificationSubscription>> GetSubscriptionsAsync(string notificationName, EntityIdentifier entityIdentifier = null);

        /// <summary>
        /// 获取给定通知的所有订阅.
        /// </summary>
        /// <param name="tenantId">Tenant id. Null for the host.</param>
        /// <param name="notificationName">Name of the notification.</param>
        /// <param name="entityIdentifier">entity identifier</param>
        Task<List<NotificationSubscription>> GetSubscriptionsAsync(int? tenantId, string notificationName, EntityIdentifier entityIdentifier = null);

        /// <summary>
        /// 获取用户的订阅通知。.
        /// </summary>
        /// <param name="user">User.</param>
        Task<List<NotificationSubscription>> GetSubscribedNotificationsAsync(UserIdentifier user);

        /// <summary>
        /// 检查用户是否订阅了通知.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="notificationName">Name of the notification.</param>
        /// <param name="entityIdentifier">entity identifier</param>
        Task<bool> IsSubscribedAsync(UserIdentifier user, string notificationName, EntityIdentifier entityIdentifier = null);
    }
}
