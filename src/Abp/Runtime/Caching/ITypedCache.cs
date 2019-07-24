using System;
using System.Threading.Tasks;

namespace Abp.Runtime.Caching
{
    /// <summary>
    /// An interface to work with cache in a typed manner.
    /// Use <see cref="CacheExtensions.AsTyped{TKey,TValue}"/> method
    /// to convert a <see cref="ICache"/> to this interface.
    /// </summary>
    /// <typeparam name="TKey">����Key</typeparam>
    /// <typeparam name="TValue">����value</typeparam>
    public interface ITypedCache<TKey, TValue> : IDisposable
    {
        /// <summary>
        /// Ψһ����.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Ĭ�ϻ���ʱ��
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// Gets the internal cache.
        /// </summary>
        ICache InternalCache { get; }

        /// <summary>
        /// ��ȡ����ʵ��
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="factory">��������ڣ��򴴽�</param>
        /// <returns>����ʵ��</returns>
        TValue Get(TKey key, Func<TKey, TValue> factory);

        /// <summary>
        /// �첽��ȡ����ʵ��
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="factory">��������ڣ��򴴽�</param>
        /// <returns>����ʵ��</returns>
        Task<TValue> GetAsync(TKey key, Func<TKey, Task<TValue>> factory);

        /// <summary>
        /// ��ȡ����ʵ�����û���򷵻�null.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>����ʵ����Null</returns>
        TValue GetOrDefault(TKey key);

        /// <summary>
        /// �첽��ȡ����ʵ�����û���򷵻�null
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>����ʵ����Null</returns>
        Task<TValue> GetOrDefaultAsync(TKey key);

        /// <summary>
        /// ���û���.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">����ʱ��</param>
        void Set(TKey key, TValue value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// �첽���û���
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">����ʱ��</param>
        Task SetAsync(TKey key, TValue value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="key">Key</param>
        void Remove(TKey key);

        /// <summary>
        /// �첽�Ƴ�����
        /// </summary>
        /// <param name="key">Key</param>
        Task RemoveAsync(TKey key);

        /// <summary>
        /// ɾ�����л���
        /// </summary>
        void Clear();

        /// <summary>
        /// �첽ɾ�����л���
        /// </summary>
        Task ClearAsync();
    }
}