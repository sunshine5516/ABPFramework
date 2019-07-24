using System;
using System.Threading;
using Abp.Dependency;

namespace Abp.Threading.Timers
{
    /// <summary>
    /// A roboust timer implementation that ensures no overlapping occurs. It waits exactly specified <see cref="Period"/> between ticks.
    /// 自定义定时器，定时器实现，确保不会发生重叠。 它在ticks之间精确等待<see cref ="Period"/>。
    /// </summary>
    //TODO: Extract interface or make all members virtual to make testing easier.
    public class AbpTimer : RunnableBase, ITransientDependency
    {
        /// <summary>
        /// 该事件根据定时器的周期定期提高。
        /// </summary>
        public event EventHandler Elapsed;

        /// <summary>
        /// 定时器的任务周期（以毫秒为单位）。
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// 指示timer是否在Timer的Start方法中引发Elapsed事件一次。
        /// 默认false
        /// </summary>
        public bool RunOnStart { get; set; }

        /// <summary>
        /// 该计时器用于以指定的时间间隔执行任务。
        /// </summary>
        private readonly Timer _taskTimer;

        /// <summary>
        /// 定时器是否在运行.
        /// </summary>
        private volatile bool _running;

        /// <summary>
        /// 表示执行任务或_taskTimer是否处于睡眠模式。.
        /// 此字段用于在停止Timer时等待正在执行的任务.
        /// </summary>
        private volatile bool _performingTasks;

        /// <summary>
        /// 创建新的定时器
        /// </summary>
        public AbpTimer()
        {
            _taskTimer = new Timer(TimerCallBack, null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="period">定时器的任务周期（以毫秒为单位）</param>
        /// <param name="runOnStart">指示Timer是否在Timer的Start方法中引发Elapsed事件一次</param>
        public AbpTimer(int period, bool runOnStart = false)
            : this()
        {
            Period = period;
            RunOnStart = runOnStart;
        }

        /// <summary>
        /// 启动定时器
        /// </summary>
        public override void Start()
        {
            if (Period <= 0)
            {
                throw new AbpException("Period should be set before starting the timer!");
            }

            base.Start();

            _running = true;
            _taskTimer.Change(RunOnStart ? 0 : Period, Timeout.Infinite);
        }

        /// <summary>
        /// Stops the timer.
        /// 如何知道一个Timer真正结束了呢？也就是说如何知道一个Timer要执行的任务已经完成（这里定义为A效果）
        /// ，同时timer已失效(这里定义为B效果)？ABP通过stop方法实现B，通过WaitToStop实现A效果。
        /// WaitToStop会一直阻塞调用他的线程直到_performingTasks变成false,
        /// 也就是说Timer要执行的任务已经完成（任务完成时会将_performingTasks设为False，并且释放锁）。
        /// </summary>
        public override void Stop()
        {
            lock (_taskTimer)
            {
                _running = false;
                _taskTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }

            base.Stop();
        }

        /// <summary>
        /// Waits the service to stop.
        /// </summary>
        public override void WaitToStop()
        {
            lock (_taskTimer)
            {
                while (_performingTasks)
                {
                    Monitor.Wait(_taskTimer);
                }
            }

            base.WaitToStop();
        }

        /// <summary>
        /// This method is called by _taskTimer.
        /// 用timer有一个弊端，就是当timer间隔时间内，任务如果没执行完，
        /// timer就会新建一个线程，从头开始执行这个任务，而上一个线程仍然继续执行，
        /// 这样就会导致系统中产生的线程过多，一会儿系统的资源就耗尽了。
        /// ABP的解决思路是在执行真正的业务方法之前，通过将timer的duetime设为无限大，
        /// 从而timer就失效了。业务方法执行完以后在恢复timer的设置。
        /// </summary>
        /// <param name="state">Not used argument</param>
        private void TimerCallBack(object state)
        {
            lock (_taskTimer)
            {
                if (!_running || _performingTasks)
                {
                    return;
                }

                _taskTimer.Change(Timeout.Infinite, Timeout.Infinite);
                _performingTasks = true;
            }

            try
            {
                if (Elapsed != null)
                {
                    Elapsed(this, new EventArgs());
                }
            }
            catch
            {

            }
            finally
            {
                lock (_taskTimer)
                {
                    _performingTasks = false;
                    if (_running)
                    {
                        _taskTimer.Change(Period, Timeout.Infinite);
                    }

                    Monitor.Pulse(_taskTimer);
                }
            }
        }
    }
}