namespace Abp.BackgroundJobs
{
    /// <summary>
    /// 后台工作的优先级。
    /// </summary>
    public enum BackgroundJobPriority : byte
    {
        /// <summary>
        /// 最低.
        /// </summary>
        Low = 5,

        /// <summary>
        /// Below normal.
        /// </summary>
        BelowNormal = 10,

        /// <summary>
        /// 正常 (默认).
        /// </summary>
        Normal = 15,

        /// <summary>
        /// Above normal.
        /// </summary>
        AboveNormal = 20,

        /// <summary>
        /// 高.
        /// </summary>
        High = 25
    }
}