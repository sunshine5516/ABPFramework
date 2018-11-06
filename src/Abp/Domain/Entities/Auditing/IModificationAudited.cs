namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// ��װ������޸ĵ��û�����Ϣ�ӿ�
    /// </summary>
    public interface IModificationAudited : IHasModificationTime
    {
        /// <summary>
        /// ����޸ĵ��û�ID.
        /// </summary>
        long? LastModifierUserId { get; set; }
    }

    /// <summary>
    /// ��װ������޸ĵ��û�����Ϣ�ӿڣ�����
    /// </summary>
    /// <typeparam name="TUser">�û�����</typeparam>
    public interface IModificationAudited<TUser> : IModificationAudited
        where TUser : IEntity<long>
    {
        /// <summary>
        /// ����޸ĵ��û�
        /// </summary>
        TUser LastModifierUser { get; set; }
    }
}