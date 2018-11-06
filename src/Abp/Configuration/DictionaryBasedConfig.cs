using System;
using System.Collections.Generic;
using Abp.Collections.Extensions;

namespace Abp.Configuration
{
    /// <summary>
    /// ����������Ϣ��.
    /// </summary>
    public class DictionaryBasedConfig : IDictionaryBasedConfig
    {
        #region ����ʵ��
        /// <summary>
        /// �����ֵ�.
        /// </summary>
        protected Dictionary<string, object> CustomSettings { get; private set; }

        /// <summary>
        /// ��ȡ/��������ֵ
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
        #region ���캯��
        /// <summary>
        /// Constructor.
        /// </summary>
        protected DictionaryBasedConfig()
        {
            CustomSettings = new Dictionary<string, object>();
        }
        #endregion

        #region ����
        /// <summary>
        /// �������ƻ�ȡ������Ϣ
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="name">����Ψһ����</param>
        public T Get<T>(string name)
        {
            var value = this[name];
            return value == null
                ? default(T)
                : (T) Convert.ChangeType(value, typeof (T));
        }

        /// <summary>
        /// ���á�������򸲸�
        /// </summary>
        /// <param name="name">����Ψһ����</param>
        /// <param name="value">������Ϣ</param>
        public void Set<T>(string name, T value)
        {
            this[name] = value;
        }
        public object Get(string name)
        {
            return Get(name, null);
        }

        /// <summary>
        /// �������ƻ�ȡ������Ϣ
        /// </summary>
        /// <param name="name">����Ψһ����</param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
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
        /// �������ƻ�ȡ������Ϣ.
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="name">����Ψһ����</param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
        public T Get<T>(string name, T defaultValue)
        {
            return (T)Get(name, (object)defaultValue);
        }

        /// <summary>
        /// �������ƻ�ȡ������Ϣ
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="name">����Ψһ����</param>
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