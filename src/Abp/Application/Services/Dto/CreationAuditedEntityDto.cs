using System;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ��װ��CreationTime��CreatorUserId��EntityDto��CreatorUserIdΪ�ɿյ�long����,ֻ֧��int���͵�������
    /// </summary>
    [Serializable]
    public abstract class CreationAuditedEntityDto : CreationAuditedEntityDto<int>
    {
        
    }

    /// <summary>
    /// ��װ��CreationTime��CreatorUserId��EntityDto��CreatorUserIdΪ�ɿյ�long����,֧�ַ������͵�������
    /// </summary>
    /// <typeparam name="TPrimaryKey">��������</typeparam>
    [Serializable]
    public abstract class CreationAuditedEntityDto<TPrimaryKey> : EntityDto<TPrimaryKey>, ICreationAudited
    {
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public long? CreatorUserId { get; set; }

        /// <summary>
        /// ���캯��.
        /// </summary>
        protected CreationAuditedEntityDto()
        {
            CreationTime = Clock.Now;
        }
    }
}