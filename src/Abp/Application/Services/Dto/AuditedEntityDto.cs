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
    /// �̳���CreationAuditedEntityDto<TPrimaryKey>��
    /// ͬʱ��װ��LastModificationTime��LastModifierUserId�����ǿɿ����͡�
    /// LastModifierUserIdΪ�����͡�֧�ַ������͵�������
    /// </summary>
    /// <typeparam name="TPrimaryKey">��������</typeparam>
    [Serializable]
    public abstract class AuditedEntityDto<TPrimaryKey> : CreationAuditedEntityDto<TPrimaryKey>, IAudited
    {
        /// <summary>
        /// ����޸�����
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// ����޸��û�
        /// </summary>
        public long? LastModifierUserId { get; set; }
    }
}