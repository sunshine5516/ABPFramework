namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// �˽ӿ��ɱ�����˵�ʵ��ʵ�֡�
    /// ����/����ʱ�Զ������������<see cref ="Entity"/>����
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