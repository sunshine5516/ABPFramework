namespace Abp.Domain.Entities
{
    /// <summary>
    /// 定义基本实体类型接口，所有实体需要继承该接口
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 实体ID
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// Checks if this entity is transient (not persisted to database and it has not an <see cref="Id"/>).
        /// </summary>
        /// <returns>True, if this entity is transient</returns>
        bool IsTransient();
    }
}
