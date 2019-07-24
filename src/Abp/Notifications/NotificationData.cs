using System;
using System.Collections.Generic;
using Abp.Collections.Extensions;
using Abp.Json;

namespace Abp.Notifications
{
    /// <summary>
    /// 用于储存真正的Notification的数据(即内容)
    /// </summary>
    [Serializable]
    public class NotificationData
    {
        /// <summary>
        /// 通知类型名称.
        /// 默认返回类全名
        /// </summary>
        public virtual string Type => GetType().FullName;

        /// <summary>
        /// Shortcut to set/get <see cref="Properties"/>.
        /// </summary>
        public object this[string key]
        {
            get { return Properties.GetOrDefault(key); }
            set { Properties[key] = value; }
        }

        /// <summary>
        /// 用于向此通知添加自定义属性.
        /// </summary>
        public Dictionary<string, object> Properties
        {
            get { return _properties; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                /* Not assign value, but add dictionary items. This is required for backward compability. */
                foreach (var keyValue in value)
                {
                    if (!_properties.ContainsKey(keyValue.Key))
                    {
                        _properties[keyValue.Key] = keyValue.Value;
                    }
                }
            }
        }
        private readonly Dictionary<string, object> _properties;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public NotificationData()
        {
            _properties = new Dictionary<string, object>();
        }

        public override string ToString()
        {
            return this.ToJsonString();
        }
    }
}