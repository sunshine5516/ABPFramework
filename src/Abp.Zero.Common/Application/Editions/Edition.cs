using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.MultiTenancy;

namespace Abp.Application.Editions
{
    /// <summary>
    /// ��ʾӦ�ó����һ���汾��
    /// </summary>
    [Table("AbpEditions")]
    [MultiTenancySide(MultiTenancySides.Host)]
    public class Edition : FullAuditedEntity
    {
        /// <summary>
        /// ������󳤶�
        /// </summary>
        public const int MaxNameLength = 32;

        /// <summary>
        /// ��ʾ������󳤶�
        /// </summary>
        public const int MaxDisplayNameLength = 64;

        /// <summary>
        /// Ψһ����
        /// </summary>
        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        [Required]
        [StringLength(MaxDisplayNameLength)]
        public virtual string DisplayName { get; set; }

        public Edition()
        {
            Name = Guid.NewGuid().ToString("N");
        }

        public Edition(string displayName)
            : this()
        {
            DisplayName = displayName;
        }
    }
}