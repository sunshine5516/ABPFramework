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
        /// </summary>
        NotificationDefinition Get(string name);

        /// <summary>
        /// 根据名称获取通知.
        /// </summary>
        NotificationDefinition GetOrNull(string name);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        IReadOnlyList<NotificationDefinition> GetAll();

        /// <summary>
        /// 检测给定的名称的通知是否属于用户
        /// </summary>
        Task<bool> IsAvailableAsync(string name, UserIdentifier user);

        /// <summary>
        /// 获取用户所有的通知信息
        /// </summary>
        /// <param name="user">User.</param>
        Task<IReadOnlyList<NotificationDefinition>> GetAllAvailableAsync(UserIdentifier user);
    }
}