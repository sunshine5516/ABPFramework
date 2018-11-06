using System;
using Abp.Domain.Entities.Auditing;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// A shortcut of <see cref="FullAuditedEntityDto{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
    /// </summary>
    [Serializable]
    public abstract class FullAuditedEntityDto : FullAuditedEntityDto<int>
    {

    }

    /// <summary>
    /// �̳���<see cref="IFullAudited{TUser}"/>�����ԣ�ͬʱ��װ����ɾ�������ԣ�IsDeleted���Լ��ɿ����͵�DeleterUserId��DeletionTime������DeleterUserIdΪ�����͡�
    /// </summary>
    /// <typeparam name="TPrimaryKey">Type of primary key</typeparam>
    [Serializable]
    public abstract class FullAuditedEntityDto<TPrimaryKey> : AuditedEntityDto<TPrimaryKey>, IFullAudited
    {
        /// <summary>
        /// �Ƿ�ɾ��?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Deleter user's Id, if this entity is deleted,
        /// </summary>
        public long? DeleterUserId { get; set; }

        /// <summary>
        /// Deletion time, if this entity is deleted,
        /// </summary>
        public DateTime? DeletionTime { get; set; }
    }
}