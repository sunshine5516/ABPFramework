namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// ��װ��CreatorUserId�������long����
    /// ����<see cref ="Entity"/>���浽���ݿ�ʱ�����Զ����ô���ʱ��ʹ������û���
    /// </summary>
    public interface ICreationAudited : IHasCreationTime
    {
        /// <summary>
        /// ������ID
        /// </summary>
        long? CreatorUserId { get; set; }
    }

    /// <summary>
    /// ��װ�˷������͵�creator
    /// </summary>
    /// <typeparam name="TUser">�û�����</typeparam>
    public interface ICreationAudited<TUser> : ICreationAudited
        where TUser : IEntity<long>
    {
        /// <summary>
        /// Reference to the creator user of this entity.
        /// </summary>
        TUser CreatorUser { get; set; }
    }
}