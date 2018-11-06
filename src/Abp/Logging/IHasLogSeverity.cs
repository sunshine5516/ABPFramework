namespace Abp.Logging
{
    /// <summary>
    /// ����<see cref ="Severity"/>���ԵĽӿڣ������<see cref ="LogSeverity"/>��
    /// </summary>
    public interface IHasLogSeverity
    {
        /// <summary>
        /// Log severity.
        /// </summary>
        LogSeverity Severity { get; set; }
    }
}