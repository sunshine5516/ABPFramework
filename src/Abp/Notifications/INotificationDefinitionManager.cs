using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Notifications
{
    /// <summary>
    /// 该接口定义根据name返回NotificationDefinition的一些方法
    /// </summary>
    public interface INotificationDefinitionManager
    {
        /// <summary>
        /// 添加.
        /// </summary>
        void Add(NotificationDefinition notificationDefinition);

        /// <summary>
        /// 根据名称获取
        /// Throws exception if there is no notification definition with given name.
        /// </summary>
        NotificationDefinition Get(string name);

        /// <summary>
        /// Gets a notification definition by name.
        /// </summary>
        NotificationDefinition GetOrNull(string name);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        IReadOnlyList<NotificationDefinition> GetAll();

        /// <summary>
        /// Checks if given notification (<see cref="name"/>) is available for given user.
        /// </summary>
        Task<bool> IsAvailableAsync(string name, UserIdentifier user);

        /// <summary>
        /// Gets all available notification definitions for given user.
        /// </summary>
        /// <param name="user">User.</param>
        Task<IReadOnlyList<NotificationDefinition>> GetAllAvailableAsync(UserIdentifier user);
    }
}