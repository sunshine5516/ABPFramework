using Abp.Domain.Entities;

namespace Abp.Domain.Repositories
{
    /// <summary>
    /// 实体参数存储库
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {

    }
}
