using System.Threading.Tasks;

namespace Abp.Notifications
{
    /// <summary>
    /// 向用户发送实时通知接口
    /// </summary>
    public interface IRealTimeNotifier
    {
        /// <summary>
        /// This method tries to deliver real time notifications to specified users.
        /// If a user is not online, it should ignore him.
        /// </summary>
        Task SendNotificationsAsync(UserNotification[] userNotifications);
    }
}