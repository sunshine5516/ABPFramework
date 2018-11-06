namespace Abp.Domain.Uow
{
    /// <summary>
    /// 在需要数据库连接时获取连接字符串。
    /// </summary>
    public interface IConnectionStringResolver
    {
        /// <summary>
        /// 获取字符串名称
        /// </summary>
        /// <param name="args">连接字符串参数.</param>
        string GetNameOrConnectionString(ConnectionStringResolveArgs args);
    }
}