using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Abp.Authorization.Users
{
    /// <summary>
    /// 用于存储外部登录服务的用户登录
    /// </summary>
    [Table("AbpUserLogins")]
    public class UserLogin : Entity<long>, IMayHaveTenant
    {
        /// <summary>
        /// <see cref="LoginProvider"/>最大长度.
        /// </summary>
        public const int MaxLoginProviderLength = 128;

        /// <summary>
        /// <see cref="ProviderKey"/>最大长度.
        /// </summary>
        public const int MaxProviderKeyLength = 256;

        public virtual int? TenantId { get; set; }

        /// <summary>
        /// 用户ID.
        /// </summary>
        public virtual long UserId { get; set; }

        /// <summary>
        /// 登录提供商.
        /// </summary>
        [Required]
        [MaxLength(MaxLoginProviderLength)]
        public virtual string LoginProvider { get; set; }

        /// <summary>
        /// Key in the <see cref="LoginProvider"/>.
        /// </summary>
        [Required]
        [MaxLength(MaxProviderKeyLength)]
        public virtual string ProviderKey { get; set; }

        public UserLogin()
        {
            
        }

        public UserLogin(int? tenantId, long userId, string loginProvider, string providerKey)
        {
            TenantId = tenantId;
            UserId = userId;
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
        }
    }
}
