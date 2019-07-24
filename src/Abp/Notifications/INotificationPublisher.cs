using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Runtime.Session;

namespace Abp.Notifications
{
    /// <summary>
    /// ���ڷ���Notification�����ȵ���INotificationStoreʵ������ʵ���������ŷַ�Notification��
    /// ����н����߲��ҽ���������5����ֱ�ӵ���INotificationDistributer���зַ�������Ͱѷַ�������ӵ���̨����������ȥ��
    /// </summary>
    public interface INotificationPublisher
    {
        /// <summary>
        /// �����µ�֪ͨ.
        /// </summary>
        /// <param name="notificationName">֪ͨΨһ����</param>
        /// <param name="data">֪ͨ����(��ѡ)</param>
        /// <param name="entityIdentifier"></param>
        /// <param name="severity">֪ͨ�ȼ�y</param>
        /// <param name="userIds">Ŀ���û�ID���������ض��û�����֪ͨ������鶩�ģ������Ϊ�գ����������Ѿ����ĵ��û�����</param>
        /// <param name="excludedUserIds">���ų����û�ID�����Խ�������Ϊ�������û�����֪ͨʱ�ų�ĳЩ�û���</param>
        /// <param name="tenantIds">Ŀ���⻧ID���������ض��⻧�Ķ����û�����֪ͨ�����userIds�������ˣ������ø��ֶ�
        /// </param>
        Task PublishAsync(
            string notificationName,
            NotificationData data = null,
            EntityIdentifier entityIdentifier = null,
            NotificationSeverity severity = NotificationSeverity.Info,
            UserIdentifier[] userIds = null,
            UserIdentifier[] excludedUserIds = null,
            int?[] tenantIds = null);
    }
}