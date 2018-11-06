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
    /// 这个类可以用来简化实现<see cref ="ICreationAudited"/>。
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体主键的类型</typeparam>
    [Serializable]
    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAudited
    {
        /// <summary>
        /// 创建时间.
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 从创建者ID
        /// </summary>
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 构造函数.
        /// </summary>
        protected CreationAuditedEntity()
        {
            CreationTime = Clock.Now;
        }
    }

    /// <summary>
    /// 这个类可以用来简化实现 <see cref="ICreationAudited{TUser}"/>.
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体主键的类型</typeparam>
    /// <typeparam name="TUser">用户类型</typeparam>
    [Serializable]
    public abstract class CreationAuditedEntity<TPrimaryKey, TUser> : CreationAuditedEntity<TPrimaryKey>, ICreationAudited<TUser>
        where TUser : IEntity<long>
    {
        /// <summary>
        /// 引用此实体的创建用户。
        /// </summary>
        [ForeignKey("CreatorUserId")]
        public virtual TUser CreatorUser { get; set; }
    }
}