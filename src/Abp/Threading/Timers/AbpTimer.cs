using System;
using System.Threading;
using Abp.Dependency;

namespace Abp.Threading.Timers
{
    /// <summary>
    /// A roboust timer implementation that ensures no overlapping occurs. It waits exactly specified <see cref="Period"/> between ticks.
    /// �Զ��嶨ʱ������ʱ��ʵ�֣�ȷ�����ᷢ���ص��� ����ticks֮�侫ȷ�ȴ�<see cref ="Period"/>��
    /// </summary>
    //TODO: Extract interface or make all members virtual to make testing easier.
    public class AbpTimer : RunnableBase, ITransientDependency
    {
        /// <summary>
        /// ���¼����ݶ�ʱ�������ڶ�����ߡ�
        /// </summary>
        public event EventHandler Elapsed;

        /// <summary>
        /// ��ʱ�����������ڣ��Ժ���Ϊ��λ����
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// ָʾtimer�Ƿ���Timer��Start����������Elapsed�¼�һ�Ρ�
        /// Ĭ��false
        /// </summary>
        public bool RunOnStart { get; set; }

        /// <summary>
        /// �ü�ʱ��������ָ����ʱ����ִ������
        /// </summary>
        private readonly Timer _taskTimer;

        /// <summary>
        /// ��ʱ���Ƿ�������.
        /// </summary>
        private volatile bool _running;

        /// <summary>
        /// ��ʾִ�������_taskTimer�Ƿ���˯��ģʽ��.
        /// ���ֶ�������ֹͣTimerʱ�ȴ�����ִ�е�����.
        /// </summary>
        private volatile bool _performingTasks;

        /// <summary>
        /// �����µĶ�ʱ��
        /// </summary>
        public AbpTimer()
        {
            _taskTimer = new Timer(TimerCallBack, null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// ���캯��.
        /// </summary>
        /// <param name="period">��ʱ�����������ڣ��Ժ���Ϊ��λ��</param>
        /// <param name="runOnStart">ָʾTimer�Ƿ���Timer��Start����������Elapsed�¼�һ��</param>
        public AbpTimer(int period, bool runOnStart = false)
            : this()
        {
            Period = period;
            RunOnStart = runOnStart;
        }

        /// <summary>
        /// ������ʱ��
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
        /// ���֪��һ��Timer�����������أ�Ҳ����˵���֪��һ��TimerҪִ�е������Ѿ���ɣ����ﶨ��ΪAЧ����
        /// ��ͬʱtimer��ʧЧ(���ﶨ��ΪBЧ��)��ABPͨ��stop����ʵ��B��ͨ��WaitToStopʵ��AЧ����
        /// WaitToStop��һֱ�������������߳�ֱ��_performingTasks���false,
        /// Ҳ����˵TimerҪִ�е������Ѿ���ɣ��������ʱ�Ὣ_performingTasks��ΪFalse�������ͷ�������
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
        /// ��timer��һ���׶ˣ����ǵ�timer���ʱ���ڣ��������ûִ���꣬
        /// timer�ͻ��½�һ���̣߳���ͷ��ʼִ��������񣬶���һ���߳���Ȼ����ִ�У�
        /// �����ͻᵼ��ϵͳ�в������̹߳��࣬һ���ϵͳ����Դ�ͺľ��ˡ�
        /// ABP�Ľ��˼·����ִ��������ҵ�񷽷�֮ǰ��ͨ����timer��duetime��Ϊ���޴�
        /// �Ӷ�timer��ʧЧ�ˡ�ҵ�񷽷�ִ�����Ժ��ڻָ�timer�����á�
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