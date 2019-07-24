using System;

namespace Abp.Configuration
{
    /// <summary>
    /// Represents a setting information.
    /// </summary>
    [Serializable]
    public class SettingInfo
    {
        /// <summary>
        /// 租户ID.
        /// 如果不是租户级别的则为null
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 用户ID.
        /// 如果不是用户级别的则为null
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 唯一名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SettingInfo()
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tenantId">TenantId for this setting. TenantId is null if this setting is not Tenant level.</param>
        /// <param name="userId">UserId for this setting. UserId is null if this setting is not user level.</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        public SettingInfo(int? tenantId, long? userId, string name, string value)
        {
            TenantId = tenantId;
            UserId = userId;
            Name = name;
            Value = value;
        }
    }
}