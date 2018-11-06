using System;
using Abp.Timing;

namespace Abp.Events.Bus
{
    /// <summary>
    /// 封装了EventData信息，触发event的源对象和时间
    /// </summary>
    [Serializable]
    public abstract class EventData : IEventData
    {
        /// <summary>
        /// 触发时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 事件源
        /// </summary>
        public object EventSource { get; set; }

        /// <summary>
        /// 构造函数.
        /// </summary>
        protected EventData()
        {
            EventTime = Clock.Now;
        }
    }
}