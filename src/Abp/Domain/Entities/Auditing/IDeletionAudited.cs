namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// ��װ��DeleterUserId�������long����
    /// </summary>
    public interface IDeletionAudited : IHasDeletionTime
    {
        /// <summary>
        /// ɾ���û�ID
        /// </summary>
        long? DeleterUserId { get; set; }
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <typeparam name="TUser">�û�����</typeparam>
    public interface IDeletionAudited<TUser> : IDeletionAudited
        where TUser : IEntity<long>
    {
        /// <summary>
        /// ɾ����ʵ�����͵��û�
        /// </summary>
        TUser DeleterUser { get; set; }
    }
}