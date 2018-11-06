using System;
using System.Threading.Tasks;
using Abp.Threading.BackgroundWorkers;

namespace Abp.BackgroundJobs
{
    /// <summary>
    /// ������ҵ�������Ľӿڡ�
    /// </summary>
    public interface IBackgroundJobManager : IBackgroundWorker
    {
        /// <summary>
        /// ��ҵ�Ŷ�
        /// </summary>
        /// <typeparam name="TJob">��ҵ����</typeparam>
        /// <typeparam name="TArgs">��ҵ����������.</typeparam>
        /// <param name="args">��ҵ����.</param>
        /// <param name="priority">��ҵ����Ȩ.</param>
        /// <param name="delay">�����ӳ٣���һ�γ���֮ǰ�ĵȴ�ʱ�䣩.</param>
        /// <returns>��̨��ҵ��Id.</returns>
        Task<string> EnqueueAsync<TJob, TArgs>(TArgs args,
            BackgroundJobPriority priority = BackgroundJobPriority.Normal, 
            TimeSpan? delay = null)
            where TJob : IBackgroundJob<TArgs>;

        /// <summary>
        /// ��ָ����jobIdɾ��һ����ҵ��
        /// </summary>
        /// <param name="jobId">jobId.</param>
        /// <returns><c>True</c> on a successfull state transition, <c>false</c> otherwise.</returns>
        Task<bool> DeleteAsync(string jobId);
    }
}