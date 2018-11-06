using System;
using Abp.Timing;

namespace Abp.Events.Bus
{
    /// <summary>
    /// ��װ��EventData��Ϣ������event��Դ�����ʱ��
    /// </summary>
    [Serializable]
    public abstract class EventData : IEventData
    {
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// �¼�Դ
        /// </summary>
        public object EventSource { get; set; }

        /// <summary>
        /// ���캯��.
        /// </summary>
        protected EventData()
        {
            EventTime = Clock.Now;
        }
    }
}