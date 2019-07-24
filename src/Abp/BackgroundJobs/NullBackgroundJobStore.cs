using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.BackgroundJobs
{
    /// <summary>
    /// <see cref="IBackgroundJobStore"/>��ʵ��.
    /// <see cref="IBackgroundJobStore"/>δʵ�ʳ־��Դ洢ʵ�ֵ��Լ�
    /// δ����<see cref="IBackgroundJobConfiguration.IsJobExecutionEnabled"/>��ʹ�ø���
    /// </summary>
    public class NullBackgroundJobStore : IBackgroundJobStore
    {
        public Task<BackgroundJobInfo> GetAsync(long jobId)
        {
            return Task.FromResult(new BackgroundJobInfo());
        }

        public Task InsertAsync(BackgroundJobInfo jobInfo)
        {
            return Task.FromResult(0);
        }

        public Task<List<BackgroundJobInfo>> GetWaitingJobsAsync(int maxResultCount)
        {
            return Task.FromResult(new List<BackgroundJobInfo>());
        }

        public Task DeleteAsync(BackgroundJobInfo jobInfo)
        {
            return Task.FromResult(0);
        }

        public Task UpdateAsync(BackgroundJobInfo jobInfo)
        {
            return Task.FromResult(0);
        }
    }
}