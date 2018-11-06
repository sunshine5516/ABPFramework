using System.ComponentModel.DataAnnotations;
using Abp.Application.Editions;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// 多租户应用
    /// </summary>
    public abstract class AbpTenant<TUser> : AbpTenantBase, IFullAudited<TUser>
        where TUser : AbpUserBase
    {
        /// <summary>
        /// Current <see cref="Edition"/> of the Tenant.
        /// </summary>
        public virtual Edition Edition { get; set; }
        public virtual int? EditionId { get; set; }

        /// <summary>
        /// 此实体的创建者用户。
        /// </summary>
        public virtual TUser CreatorUser { get; set; }

        /// <summary>
        /// 此实体的最后一个修改的用户。
        /// </summary>
        public virtual TUser LastModifierUser { get; set; }

        /// <summary>
        /// 此实体删除者
        /// </summary>
        public virtual TUser DeleterUser { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected AbpTenant()
        {
            IsActive = true;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tenancyName">唯一名称</param>
        /// <param name="name">显示名称</param>
        protected AbpTenant(string tenancyName, string name)
            : this()
        {
            TenancyName = tenancyName;
            Name = name;
        }
    }
}
