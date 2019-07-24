using System;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Abp.Notifications
{
    /// <summary>
    /// ���û��ַ�֪ͨ�ӿڣ�Ҳ���ǽ���Notification��User�Ĺ�ϵ.
    /// </summary>
    public interface INotificationDistributer : IDomainService
    {
        /// <summary>
        /// ���û��ַ�������֪ͨ��
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        Task DistributeAsync(Guid notificationId);
    }
}