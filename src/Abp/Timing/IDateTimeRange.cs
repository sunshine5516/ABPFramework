using System;

namespace Abp.Timing
{
    /// <summary>
    /// 时间区间接口.
    /// </summary>
    public interface IDateTimeRange
    {
        /// <summary>
        /// 开始时间.
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间.
        /// </summary>
        DateTime EndTime { get; set; }
    }
}
