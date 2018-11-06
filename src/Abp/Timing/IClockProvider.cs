using System;

namespace Abp.Timing
{
    /// <summary>
    /// 提供获取当前时间和标准化时间的接口
    /// </summary>
    public interface IClockProvider
    {
        /// <summary>
        /// 当前时间.
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// 获取类别.
        /// </summary>
        DateTimeKind Kind { get; }

        /// <summary>
        /// 是否支持多个时区？.
        /// </summary>
        bool SupportsMultipleTimezone { get; }

        /// <summary>
        /// 对给定的<see cref ="DateTime"/>进行规范化。
        /// </summary>
        /// <param name="dateTime">DateTime to be normalized.</param>
        /// <returns>Normalized DateTime</returns>
        DateTime Normalize(DateTime dateTime);
    }
}