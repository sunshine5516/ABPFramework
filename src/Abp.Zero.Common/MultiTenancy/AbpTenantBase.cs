using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Runtime.Security;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// �⻧����.
    /// </summary>
    [Table("AbpTenants")]
    [MultiTenancySide(MultiTenancySides.Host)]
    public abstract class AbpTenantBase : FullAuditedEntity<int>, IPassivable
    {
        /// <summary>
        /// ������󳤶�.
        /// </summary>
        public const int MaxTenancyNameLength = 64;

        /// <summary>
        /// <see cref="ConnectionString"/>��󳤶�.
        /// </summary>
        public const int MaxConnectionStringLength = 1024;

        /// <summary>
        /// Ĭ������
        /// </summary>
        public const string DefaultTenantName = "Default";

        /// <summary>
        /// "^[a-zA-Z][a-zA-Z0-9_-]{1,}$".
        /// </summary>
        public const string TenancyNameRegex = "^[a-zA-Z][a-zA-Z0-9_-]{1,}$";

        /// <summary>
        /// <see cref="Name"/>��󳤶�.
        /// </summary>
        public const int MaxNameLength = 128;

        /// <summary>
        /// �⻧���ƣ�����Ψһ.
        /// ������WebӦ�ó�����������������
        /// </summary>
        [Required]
        [StringLength(MaxTenancyNameLength)]
        public virtual string TenancyName { get; set; }

        /// <summary>
        /// ��ʾ����.
        /// </summary>
        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// ���ݿ������ַ���
        /// ������⻧�洢���������ݿ��У������Ϊnull��
        /// Use <see cref="SimpleStringCipher"/> to encrypt/decrypt this.
        /// </summary>
        [StringLength(MaxConnectionStringLength)]
        public virtual string ConnectionString { get; set; }

        /// <summary>
        /// �⻧�Ƿ����
        /// ������⻧δδ����״̬���������⻧���͵��û�����ʹ�ø�Ӧ�ã�
        /// </summary>
        public virtual bool IsActive { get; set; }
    }
}