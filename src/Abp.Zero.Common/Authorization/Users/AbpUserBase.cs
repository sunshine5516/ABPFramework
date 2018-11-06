using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Configuration;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;

namespace Abp.Authorization.Users
{
    /// <summary>
    /// �û�����.
    /// </summary>
    [Table("AbpUsers")]
    public abstract class AbpUserBase : FullAuditedEntity<long>, IMayHaveTenant, IPassivable
    {
        /// <summary>
        /// �û�����󳤶�
        /// </summary>
        public const int MaxUserNameLength = 32;

        /// <summary>
        /// �����ַ��󳤶�
        /// </summary>
        public const int MaxEmailAddressLength = 256;

        /// <summary>
        /// ������󳤶�
        /// </summary>
        public const int MaxNameLength = 32;

        /// <summary>
        /// �յ���󳤶�
        /// </summary>
        public const int MaxSurnameLength = 32;

        /// <summary>
        /// Maximum length of the <see cref="AuthenticationSource"/> property.
        /// </summary>
        public const int MaxAuthenticationSourceLength = 64;

        /// <summary>
        /// ����Ա����.
        /// admin�޷�ɾ��������Ա��UserName�޷����ġ�
        /// </summary>
        public const string AdminUserName = "admin";

        /// <summary>
        /// ���볤�����ֵ
        /// </summary>
        public const int MaxPasswordLength = 128;

        /// <summary>
        /// Maximum length of the <see cref="Password"/> without hashed.
        /// </summary>
        public const int MaxPlainPasswordLength = 32;

        /// <summary>
        /// �����ʼ�ȷ��ֵ����󳤶�
        /// </summary>
        public const int MaxEmailConfirmationCodeLength = 328;

        /// <summary>
        /// ��������ֵ����󳤶�
        /// </summary>
        public const int MaxPasswordResetCodeLength = 328;

        /// <summary>
        /// Authorization source name.
        /// ������ⲿԴ��������������Ϊ�ⲿ��֤Դ���ơ�
        /// Ĭ��: null.
        /// </summary>
        [MaxLength(MaxAuthenticationSourceLength)]
        public virtual string AuthenticationSource { get; set; }

        /// <summary>
        /// �û��ĵ�¼��������һ���⻧��˵Ӧ����Ψһ�ġ�
        /// </summary>
        [Required]
        [StringLength(MaxUserNameLength)]
        public virtual string UserName { get; set; }

        /// <summary>
        /// �⻧ID.
        /// </summary>
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// �����ʼ���ַ��Ψһ��
        /// </summary>
        [Required]
        [StringLength(MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        /// <summary>
        /// �û�������.
        /// </summary>
        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// �û�����.
        /// </summary>
        [Required]
        [StringLength(MaxSurnameLength)]
        public virtual string Surname { get; set; }

        /// <summary>
        /// ȫ��
        /// </summary>
        [NotMapped]
        public virtual string FullName { get { return this.Name + " " + this.Surname; } }

        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [StringLength(MaxPasswordLength)]
        public virtual string Password { get; set; }

        /// <summary>
        /// ȷ���ʼ�
        /// </summary>
        [StringLength(MaxEmailConfirmationCodeLength)]
        public virtual string EmailConfirmationCode { get; set; }

        /// <summary>
        /// ��������ֵ.
        /// �����Ϊ������Ч
        /// ����һ���÷������ú��������Ϊnull��
        /// </summary>
        [StringLength(MaxPasswordResetCodeLength)]
        public virtual string PasswordResetCode { get; set; }

        /// <summary>
        /// �ǳ�����
        /// </summary>
        public virtual DateTime? LockoutEndDateUtc { get; set; }

        /// <summary>
        /// ����ʧ�ܼ�����
        /// </summary>
        public virtual int AccessFailedCount { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        public virtual bool IsLockoutEnabled { get; set; }

        /// <summary>
        /// �绰
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Is the <see cref="PhoneNumber"/> confirmed.
        /// </summary>
        public virtual bool IsPhoneNumberConfirmed { get; set; }

        /// <summary>
        /// ��ȫ��.
        /// </summary>
        public virtual string SecurityStamp { get; set; }

        /// <summary>
        /// �Ƿ�������˫���������֤��
        /// </summary>
        public virtual bool IsTwoFactorEnabled { get; set; }

        /// <summary>
        /// �û��ĵ�¼���塣
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<UserLogin> Logins { get; set; }

        /// <summary>
        /// �û���ɫ.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<UserRole> Roles { get; set; }

        /// <summary>
        /// Claims of this user.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<UserClaim> Claims { get; set; }

        /// <summary>
        /// �û���Ȩ��
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<UserPermissionSetting> Permissions { get; set; }

        /// <summary>
        /// ������Ϣ.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<Setting> Settings { get; set; }

        /// <summary>
        /// �Ƿ���ȷ��<see cref="AbpUserBase.EmailAddress"/>.
        /// </summary>
        public virtual bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// �Ƿ񼤻�
        /// ���δ������޷�ʹ�ø�ϵͳ
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public virtual DateTime? LastLoginTime { get; set; }

        protected AbpUserBase()
        {
            IsActive = true;
            IsLockoutEnabled = true;
            SecurityStamp = SequentialGuidGenerator.Instance.Create().ToString();
        }

        public virtual void SetNewPasswordResetCode()
        {
            PasswordResetCode = Guid.NewGuid().ToString("N").Truncate(MaxPasswordResetCodeLength);
        }

        public virtual void SetNewEmailConfirmationCode()
        {
            EmailConfirmationCode = Guid.NewGuid().ToString("N").Truncate(MaxEmailConfirmationCodeLength);
        }

        /// <summary>
        /// Creates <see cref="UserIdentifier"/> from this User.
        /// </summary>
        /// <returns></returns>
        public virtual UserIdentifier ToUserIdentifier()
        {
            return new UserIdentifier(TenantId, Id);
        }

        public override string ToString()
        {
            return $"[User {Id}] {UserName}";
        }
    }
}