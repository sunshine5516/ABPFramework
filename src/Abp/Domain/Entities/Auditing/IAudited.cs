namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// 此接口由必须审核的实体实现。
    /// 保存/更新时自动设置相关属性<see cref ="Entity"/>对象。
    /// </summary>
    public interface IAudited : ICreationAudited, IModificationAudited
    {

    }

    /// <summary>
    /// Adds navigation properties to <see cref="IAudited"/> interface for user.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IAudited<TUser> : IAudited, ICreationAudited<TUser>, IModificationAudited<TUser>
        where TUser : IEntity<long>
    {

    }
}