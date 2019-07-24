using System;
using System.Collections.Generic;
using Abp.Application.Features;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Localization;

namespace Abp.Notifications
{
    /// <summary>
    /// 封装Notification Definnition 的信息.
    /// </summary>
    public class NotificationDefinition
    {
        /// <summary>
        /// 唯一名称
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public Type EntityType { get; private set; }

        /// <summary>
        /// 显示名称
        /// Optional.
        /// </summary>
        public ILocalizableString DisplayName { get; set; }

        /// <summary>
        /// 描述
        /// Optional.
        /// </summary>
        public ILocalizableString Description { get; set; }

        /// <summary>
        /// 权限依赖关系。 如果满足该依赖关系，则该通知将可供用户使用。
        /// Optional.
        /// </summary>
        public IPermissionDependency PermissionDependency { get; set; }
        
        /// <summary>
        /// A feature dependency. This notification will be available to a tenant if this feature is enabled.
        /// Optional.
        /// </summary>
        public IFeatureDependency FeatureDependency { get; set; }

        /// <summary>
        /// Gets/sets arbitrary objects related to this object.
        /// Gets null if given key does not exists.
        /// This is a shortcut for <see cref="Attributes"/> dictionary.
        /// </summary>
        /// <param name="key">Key</param>
        public object this[string key]
        {
            get { return Attributes.GetOrDefault(key); }
            set { Attributes[key] = value; }
        }

        /// <summary>
        /// 与此对象相关的任意对象
        /// 对象必须是可序列化的
        /// </summary>
        public IDictionary<string, object> Attributes { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">唯一名称.</param>
        /// <param name="entityType">类型.</param>
        /// <param name="displayName">显示名称.</param>
        /// <param name="description">描述</param>
        /// <param name="permissionDependency">权限依赖关系。 如果满足该依赖关系，则该通知将可供用户使用。.</param>
        /// <param name="featureDependency">A feature dependency. This notification will be available to a tenant if this feature is enabled.</param>
        public NotificationDefinition(string name, Type entityType = null, ILocalizableString displayName = null, ILocalizableString description = null, IPermissionDependency permissionDependency = null, IFeatureDependency featureDependency = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "name can not be null, empty or whitespace!");
            }
            
            Name = name;
            EntityType = entityType;
            DisplayName = displayName;
            Description = description;
            PermissionDependency = permissionDependency;
            FeatureDependency = featureDependency;

            Attributes = new Dictionary<string, object>();
        }
    }
}
