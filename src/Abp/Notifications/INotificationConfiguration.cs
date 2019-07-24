using Abp.Collections;

namespace Abp.Notifications
{
    /// <summary>
    /// notification配置.
    /// </summary>
    public interface INotificationConfiguration
    {
        /// <summary>
        /// Notification providers.
        /// </summary>
        ITypeList<NotificationProvider> Providers { get; }
    }
}