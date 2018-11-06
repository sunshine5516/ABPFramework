using System;

namespace Abp.Configuration
{
    /// <summary>
    /// ����ӿ���ʹ���ֵ�������á�
    /// </summary>
    public interface IDictionaryBasedConfig
    {
        /// <summary>
        /// ���á�������򸲸�
        /// </summary>
        /// <param name="name">����Ψһ����</param>
        /// <param name="value">������Ϣ</param>
        void Set<T>(string name, T value);

        
        object Get(string name);

        /// <summary>
        /// �������ƻ�ȡ������Ϣ
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="name">����Ψһ����</param>
        T Get<T>(string name);

        /// <summary>
        /// �������ƻ�ȡ������Ϣ
        /// </summary>
        /// <param name="name">����Ψһ����</param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
        object Get(string name, object defaultValue);

        /// <summary>
        /// �������ƻ�ȡ������Ϣ.
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="name">����Ψһ����</param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
        T Get<T>(string name, T defaultValue);

        /// <summary>
        /// �������ƻ�ȡ������Ϣ
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="name">����Ψһ����</param>
        /// <param name="creator">The function that will be called to create if given configuration is not found</param>
        /// <returns>Value of the configuration or null if not found</returns>
        T GetOrCreate<T>(string name, Func<T> creator);
    }
}