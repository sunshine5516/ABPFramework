using System;
using System.Collections.Generic;
using Abp.Collections.Extensions;

namespace Abp.Configuration
{
    /// <summary>
    /// 设置配置信息类.
    /// </summary>
    public class DictionaryBasedConfig : IDictionaryBasedConfig
    {
        #region 声明实例
        /// <summary>
        /// 配置字典.
        /// </summary>
        protected Dictionary<string, object> CustomSettings { get; private set; }

        /// <summary>
        /// 获取/设置配置值
        /// Returns null if no config with given name.
        /// </summary>
        /// <param name="name">Name of the config</param>
        /// <returns>Value of the config</returns>
        public object this[string name]
        {
            get { return CustomSettings.GetOrDefault(name); }
            set { CustomSettings[name] = value; }
        }
        #endregion
        #region 构造函数
        /// <summary>
        /// Constructor.
        /// </summary>
        protected DictionaryBasedConfig()
        {
            CustomSettings = new Dictionary<string, object>();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 根据名称获取配置信息
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="name">配置唯一名称</param>
        public T Get<T>(string name)
        {
            var value = this[name];
            return value == null
                ? default(T)
                : (T) Convert.ChangeType(value, typeof (T));
        }

        /// <summary>
        /// 设置。如果有则覆盖
        /// </summary>
        /// <param name="name">配置唯一名称</param>
        /// <param name="value">配置信息</param>
        public void Set<T>(string name, T value)
        {
            this[name] = value;
        }
        public object Get(string name)
        {
            return Get(name, null);
        }

        /// <summary>
        /// 根据名称获取配置信息
        /// </summary>
        /// <param name="name">配置唯一名称</param>
        /// <param name="defaultValue">默认值</param>
        public object Get(string name, object defaultValue)
        {
            var value = this[name];
            if (value == null)
            {
                return defaultValue;
            }

            return this[name];
        }

        /// <summary>
        /// 根据名称获取配置信息.
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="name">配置唯一名称</param>
        /// <param name="defaultValue">默认值</param>
        public T Get<T>(string name, T defaultValue)
        {
            return (T)Get(name, (object)defaultValue);
        }

        /// <summary>
        /// 根据名称获取配置信息
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="name">配置唯一名称</param>
        /// <param name="creator">The function that will be called to create if given configuration is not found</param>
        /// <returns>Value of the configuration or null if not found</returns>
        public T GetOrCreate<T>(string name, Func<T> creator)
        {
            var value = Get(name);
            if (value == null)
            {
                value = creator();
                Set(name, value);
            }
            return (T) value;
        }
        #endregion
    }
}