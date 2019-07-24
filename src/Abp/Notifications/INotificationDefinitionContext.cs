namespace Abp.Notifications
{
    /// <summary>
    /// 在定义通知时用作上下文.
    /// </summary>
    public interface INotificationDefinitionContext
    {
        /// <summary>
        /// Gets the notification definition manager.
        /// </summary>
        INotificationDefinitionManager Manager { get; }
    }
}