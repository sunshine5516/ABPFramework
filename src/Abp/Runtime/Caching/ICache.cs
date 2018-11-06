using System;
using System.Threading.Tasks;

namespace Abp.Runtime.Caching
{
    /// <summary>
    /// ����ӿ�
    /// </summary>
    public interface ICache : IDisposable
    {
        /// <summary>
        /// ����Ψһ����.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ����Ĭ�Ϲ���ʱ��.
        /// Ĭ��1H
        /// ����ͨ�����øı�
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// ������Ŀ��Ĭ�Ͼ��Թ���ʱ�䡣
        /// Ĭ�� null
        /// </summary>
        TimeSpan? DefaultAbsoluteExpireTime { get; set; }

        /// <summary>
        /// ��ȡ����ʵ��
        /// �˷������ػ����ṩ����ʧ�ܣ�����¼���ǣ�����������ṩ����ʧ�ܣ���ʹ�ù���������ȡ����
        /// </summary>
        object Get(string key, Func<string, object> factory);

        /// <summary>
        /// �첽��ȡ����ʵ��
        /// �˷������ػ����ṩ����ʧ�ܣ�����¼���ǣ�����������ṩ����ʧ�ܣ���ʹ�ù���������ȡ����
        /// </summary>
        Task<object> GetAsync(string key, Func<string, Task<object>> factory);

        /// <summary>
        /// ��ȡ����ʵ����Ĭ��NULL
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        object GetOrDefault(string key);

        /// <summary>
        /// �첽��ȡ����ʵ����Ĭ��NULL.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Cached item or null if not found</returns>
        Task<object> GetOrDefaultAsync(string key);

        /// <summary>
        /// ���û���
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">���ʱ��</param>
        /// <param name="absoluteExpireTime">����ʱ��</param>
        void Set(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// �첽���û���
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">���ʱ��</param>
        /// <param name="absoluteExpireTime">����ʱ��</param>
        Task SetAsync(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="key">Key</param>
        void Remove(string key);

        /// <summary>
        /// �첽�Ƴ�����
        /// </summary>
        /// <param name="key">Key</param>
        Task RemoveAsync(string key);

        /// <summary>
        /// �������
        /// </summary>
        void Clear();

        /// <summary>
        /// �첽�������
        /// </summary>
        Task ClearAsync();
    }
}