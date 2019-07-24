using Abp.Dependency;

namespace Abp.Notifications
{
    /// <summary>
    /// 抽象基类，用于向<see cref="INotificationDefinitionManager"/>中添加<see cref="NotificationDefinition"/>
    /// </summary>
    public abstract class NotificationProvider : ITransientDependency
    {
        /// <summary>
        /// Used to add/manipulate notification definitions.
        /// </summary>
        /// <param name="context">Context</param>
        public abstract void SetNotifications(INotificationDefinitionContext context);
    }
}