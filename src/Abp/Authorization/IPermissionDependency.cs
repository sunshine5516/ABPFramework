using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// 用于检查依赖关系的接口。
    /// </summary>
    public interface IPermissionDependency
    {
        /// <summary>
        /// 检查是否满足权限依赖性。
        /// </summary>
        /// <param name="context">Context.</param>
        Task<bool> IsSatisfiedAsync(IPermissionDependencyContext context);
    }
}