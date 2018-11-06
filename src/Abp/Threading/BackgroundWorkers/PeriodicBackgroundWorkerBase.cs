using System;
using Abp.Threading.Timers;

namespace Abp.Threading.BackgroundWorkers
{
    /// <summary>
    /// ͨ����װAbpTimerʵ�ֶ�ʱ����ִ������Ĺ��ܡ�
    /// ������Ͷ����һ�����󷽷�DoWork. AbpTimer���ջᶨʱִ�����������
    /// </summary>
    public abstract class PeriodicBackgroundWorkerBase : BackgroundWorkerBase
    {
        protected readonly AbpTimer Timer;

        /// <summary>
        /// ʵ��������
        /// </summary>
        /// <param name="timer">A timer.</param>
        protected PeriodicBackgroundWorkerBase(AbpTimer timer)
        {
            Timer = timer;
            Timer.Elapsed += Timer_Elapsed;
        }

        public override void Start()
        {
            base.Start();
            Timer.Start();
        }

        public override void Stop()
        {
            Timer.Stop();
            base.Stop();
        }

        public override void WaitToStop()
        {
            Timer.WaitToStop();
            base.WaitToStop();
        }

        /// <summary>
        /// Handles the Elapsed event of the Timer.
        /// </summary>
        private void Timer_Elapsed(object sender, System.EventArgs e)
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.ToString(), ex);
            }
        }

        /// <summary>
        /// ִ�е�����
        /// </summary>
        protected abstract void DoWork();
    }
}