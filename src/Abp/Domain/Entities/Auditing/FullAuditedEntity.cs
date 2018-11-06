using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// (<see cref="int"/>)�����Ŀ��ʵ��.
    /// </summary>
    [Serializable]
    public abstract class FullAuditedEntity : FullAuditedEntity<int>, IEntity
    {

    }

    /// <summary>
    /// ʵ��<see cref="IFullAudited"/>��Ϊ��ȫ���ʵ��Ļ��ࡣ
    /// </summary>
    /// <typeparam name="TPrimaryKey">ʵ����������</typeparam>
    [Serializable]
    public abstract class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, IFullAudited
    {
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// ɾ��ʵ����û���ID
        /// </summary>
        public virtual long? DeleterUserId { get; set; }

        /// <summary>
        /// ɾ��ʱ��.
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }
    }

    /// <summary>
    /// ʵ��<see cref="IFullAudited"/>��Ϊ��ȫ���ʵ��Ļ���.
    /// </summary>
    /// <typeparam name="TPrimaryKey">ʵ����������</typeparam>
    /// <typeparam name="TUser">�û�����</typeparam>
    [Serializable]
    public abstract class FullAuditedEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey, TUser>, IFullAudited<TUser>
        where TUser : IEntity<long>
    {
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// ɾ����ʵ����û�.
        /// </summary>
        [ForeignKey("DeleterUserId")]
        public virtual TUser DeleterUser { get; set; }

        /// <summary>
        /// ɾ��ʵ����û���ID
        /// </summary>
        public virtual long? DeleterUserId { get; set; }

        /// <summary>
        /// ɾ��ʱ��
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }
    }
}