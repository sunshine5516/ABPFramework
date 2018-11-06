using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Timing;

namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// A shortcut of <see cref="CreationAuditedEntity{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
    /// </summary>
    [Serializable]
    public abstract class CreationAuditedEntity : CreationAuditedEntity<int>, IEntity
    {

    }

    /// <summary>
    /// ��������������ʵ��<see cref ="ICreationAudited"/>��
    /// </summary>
    /// <typeparam name="TPrimaryKey">ʵ������������</typeparam>
    [Serializable]
    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAudited
    {
        /// <summary>
        /// ����ʱ��.
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// �Ӵ�����ID
        /// </summary>
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// ���캯��.
        /// </summary>
        protected CreationAuditedEntity()
        {
            CreationTime = Clock.Now;
        }
    }

    /// <summary>
    /// ��������������ʵ�� <see cref="ICreationAudited{TUser}"/>.
    /// </summary>
    /// <typeparam name="TPrimaryKey">ʵ������������</typeparam>
    /// <typeparam name="TUser">�û�����</typeparam>
    [Serializable]
    public abstract class CreationAuditedEntity<TPrimaryKey, TUser> : CreationAuditedEntity<TPrimaryKey>, ICreationAudited<TUser>
        where TUser : IEntity<long>
    {
        /// <summary>
        /// ���ô�ʵ��Ĵ����û���
        /// </summary>
        [ForeignKey("CreatorUserId")]
        public virtual TUser CreatorUser { get; set; }
    }
}