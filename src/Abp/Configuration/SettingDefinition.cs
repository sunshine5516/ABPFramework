using System;
using Abp.Localization;

namespace Abp.Configuration
{
    /// <summary>
    /// 定义一个setting.
    /// 设置文件用于配置和更改应用程序的行为。
    /// </summary>
    public class SettingDefinition
    {
        /// <summary>
        /// 唯一名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 展示的名称       
        /// </summary>
        public ILocalizableString DisplayName { get; set; }

        /// <summary>
        /// 此设置的简要说明。
        /// </summary>
        public ILocalizableString Description { get; set; }

        /// <summary>
        /// 范围
        /// Default value: <see cref="SettingScopes.Application"/>.
        /// </summary>
        public SettingScopes Scopes { get; set; }

        /// <summary>
        /// 是否继承
        /// Default: True.
        /// </summary>
        public bool IsInherited { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public SettingDefinitionGroup Group { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 客户是否可见
        /// 某些设置对客户可见（例如电子邮件服务器密码）可能很危险。
        /// 默认值: false.
        /// </summary>
        public bool IsVisibleToClients { get; set; }

        /// <summary>
        /// 用于存储与此设置相关的自定义对象。
        /// </summary>
        public object CustomData { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">名字</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="displayName">展示名称</param>
        /// <param name="group">分组</param>
        /// <param name="description">描述</param>
        /// <param name="scopes">作用域.</param>
        /// <param name="isVisibleToClients">客户是否可见</param>
        /// <param name="isInherited">是否继承.</param>
        /// <param name="customData">Can be used to store a custom object related to this setting</param>
        public SettingDefinition(
            string name, 
            string defaultValue, 
            ILocalizableString displayName = null, 
            SettingDefinitionGroup group = null, 
            ILocalizableString description = null, 
            SettingScopes scopes = SettingScopes.Application, 
            bool isVisibleToClients = false, 
            bool isInherited = true,
            object customData = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            DefaultValue = defaultValue;
            DisplayName = displayName;
            Group = @group;
            Description = description;
            Scopes = scopes;
            IsVisibleToClients = isVisibleToClients;
            IsInherited = isInherited;
            CustomData = customData;
        }
    }
}
