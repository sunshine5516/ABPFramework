namespace Abp.Logging
{
    /// <summary>
    /// 定义<see cref ="Severity"/>属性的接口（请参阅<see cref ="LogSeverity"/>）
    /// </summary>
    public interface IHasLogSeverity
    {
        /// <summary>
        /// Log severity.
        /// </summary>
        LogSeverity Severity { get; set; }
    }
}