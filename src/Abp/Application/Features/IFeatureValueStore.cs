using System.Threading.Tasks;

namespace Abp.Application.Features
{
    /// <summary>
    /// 存储feature值.
    /// 接口定义了获取Feature值的方法
    /// </summary>
    public interface IFeatureValueStore
    {
        /// <summary>
        /// 获取feature值或返回null.
        /// </summary>
        /// <param name="tenantId">The tenant id.</param>
        /// <param name="feature">The feature.</param>
        Task<string> GetValueOrNullAsync(int tenantId, Feature feature);
    }
}