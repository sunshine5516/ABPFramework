using System.Threading.Tasks;

namespace Abp.Application.Features
{
    /// <summary>
    /// �洢featureֵ.
    /// �ӿڶ����˻�ȡFeatureֵ�ķ���
    /// </summary>
    public interface IFeatureValueStore
    {
        /// <summary>
        /// ��ȡfeatureֵ�򷵻�null.
        /// </summary>
        /// <param name="tenantId">The tenant id.</param>
        /// <param name="feature">The feature.</param>
        Task<string> GetValueOrNullAsync(int tenantId, Feature feature);
    }
}