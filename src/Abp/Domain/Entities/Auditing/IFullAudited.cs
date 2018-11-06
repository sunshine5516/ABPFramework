namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// 该接口添加了<see cref="IDeletionAudited"/> to <see cref="IAudited"/>
    /// 实现了实体的全面审计.
    /// </summary>
    public interface IFullAudited : IAudited, IDeletionAudited
    {
        
    }

    /// <summary>
    /// Adds navigation properties to <see cref="IFullAudited"/> interface for user.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IFullAudited<TUser> : IAudited<TUser>, IFullAudited, IDeletionAudited<TUser>
        where TUser : IEntity<long>
    {

    }
}