using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Configuration
{
    /// <summary>
    /// �ӿڶ�������ط������ڴ�����Դ��ȡ�͸���settingֵ
    /// </summary>
    public interface ISettingStore
    {
        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <param name="tenantId">�⻧ID</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="name">��������</param>
        /// <returns>Settingʵ��</returns>
        Task<SettingInfo> GetSettingOrNullAsync(int? tenantId, long? userId, string name);

        /// <summary>
        /// ɾ������ֵ
        /// </summary>
        /// <param name="setting">Settingʵ��</param>
        Task DeleteAsync(SettingInfo setting);

        /// <summary>
        /// �������.
        /// </summary>
        /// <param name="setting">Setting to add</param>
        Task CreateAsync(SettingInfo setting);

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="setting">Setting to add</param>
        Task UpdateAsync(SettingInfo setting);

        /// <summary>
        /// ��ȡ���ü���
        /// </summary>
        /// <param name="tenantId">�⻧ID</param>
        /// <param name="userId">�û�ID</param>
        /// <returns>���ü���</returns>
        Task<List<SettingInfo>> GetAllListAsync(int? tenantId, long? userId);
    }
}