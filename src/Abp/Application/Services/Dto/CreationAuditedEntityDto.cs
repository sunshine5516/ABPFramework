using System;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// 封装了CreationTime和CreatorUserId的EntityDto，CreatorUserId为可空的long类型,只支持int类型的主键。
    /// </summary>
    [Serializable]
    public abstract class CreationAuditedEntityDto : CreationAuditedEntityDto<int>
    {
        
    }

    /// <summary>
    /// 封装了CreationTime和CreatorUserId的EntityDto，CreatorUserId为可空的long类型,支持泛型类型的主键。
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    [Serializable]
    public abstract class CreationAuditedEntityDto<TPrimaryKey> : EntityDto<TPrimaryKey>, ICreationAudited
    {
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public long? CreatorUserId { get; set; }

        /// <summary>
        /// 构造函数.
        /// </summary>
        protected CreationAuditedEntityDto()
        {
            CreationTime = Clock.Now;
        }
    }
}