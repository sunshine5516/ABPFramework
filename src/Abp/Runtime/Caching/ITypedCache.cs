using System;
using System.Threading.Tasks;

namespace Abp.Runtime.Caching
{
    /// <summary>
    /// An interface to work with cache in a typed manner.
    /// Use <see cref="CacheExtensions.AsTyped{TKey,TValue}"/> method
    /// to convert a <see cref="ICache"/> to this interface.
    /// </summary>
    /// <typeparam name="TKey">缓存Key</typeparam>
    /// <typeparam name="TValue">缓存value</typeparam>
    public interface ITypedCache<TKey, TValue> : IDisposable
    {
        /// <summary>
        /// 唯一名称.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 默认缓存时间
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// Gets the internal cache.
        /// </summary>
        ICache InternalCache { get; }

        /// <summary>
        /// 获取缓存实例
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="factory">如果不存在，则创建</param>
        /// <returns>缓存实例</returns>
        TValue Get(TKey key, Func<TKey, TValue> factory);

        /// <summary>
        /// 异步获取缓存实例
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="factory">如果不存在，则创建</param>
        /// <returns>缓存实例</returns>
        Task<TValue> GetAsync(TKey key, Func<TKey, Task<TValue>> factory);

        /// <summary>
        /// 获取缓存实例如果没有则返回null.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>缓存实例或Null</returns>
        TValue GetOrDefault(TKey key);

        /// <summary>
        /// 异步获取缓存实例如果没有则返回null
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>缓存实例或Null</returns>
        Task<TValue> GetOrDefaultAsync(TKey key);

        /// <summary>
        /// 设置缓存.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">缓存时间</param>
        void Set(TKey key, TValue value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// 异步设置缓存
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">缓存时间</param>
        Task SetAsync(TKey key, TValue value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">Key</param>
        void Remove(TKey key);

        /// <summary>
        /// 异步移除缓存
        /// </summary>
        /// <param name="key">Key</param>
        Task RemoveAsync(TKey key);

        /// <summary>
        /// 删除所有缓存
        /// </summary>
        void Clear();

        /// <summary>
        /// 异步删除所有缓存
        /// </summary>
        Task ClearAsync();
    }
}