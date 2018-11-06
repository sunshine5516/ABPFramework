namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// �ýӿ������<see cref="IDeletionAudited"/> to <see cref="IAudited"/>
    /// ʵ����ʵ���ȫ�����.
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