using System;
using Abp.Domain.Entities.Auditing;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class AuditedEntityDto : AuditedEntityDto<int>
    {

    }

    /// <summary>
    /// 继承了CreationAuditedEntityDto<TPrimaryKey>，
    /// 同时封装了LastModificationTime和LastModifierUserId，都是可空类型。
    /// LastModifierUserId为长整型。支持泛型类型的主键。
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    [Serializable]
    public abstract class AuditedEntityDto<TPrimaryKey> : CreationAuditedEntityDto<TPrimaryKey>, IAudited
    {
        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public long? LastModifierUserId { get; set; }
    }
}