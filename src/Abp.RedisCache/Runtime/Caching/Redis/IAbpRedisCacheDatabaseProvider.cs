using StackExchange.Redis;

namespace Abp.Runtime.Caching.Redis
{
    /// <summary>
    /// 获取redis缓存
    /// </summary>
    public interface IAbpRedisCacheDatabaseProvider 
    {
        /// <summary>
        /// 获取数据库连接.
        /// </summary>
        IDatabase GetDatabase();
    }
}
