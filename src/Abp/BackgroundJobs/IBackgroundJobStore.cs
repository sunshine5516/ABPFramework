using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.BackgroundJobs
{
    /// <summary>
    /// ���ڳ־û���̨����BackgroundJobInfo������洢/��ȡ��̨��ҵ�Ľӿڡ�
    /// </summary>
    public interface IBackgroundJobStore
    {
        /// <summary>
        /// ����ID��ȡBackgroundJobInfo
        /// </summary>
        /// <param name="jobId">ID</param>
        /// <returns>The BackgroundJobInfo object.</returns>
        Task<BackgroundJobInfo> GetAsync(long jobId);

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="jobInfo">Job information.</param>
        Task InsertAsync(BackgroundJobInfo jobInfo);

        /// <summary>
        /// ��ȡ�ȴ��е�����
        /// </summary>
        /// <param name="maxResultCount">Maximum result count.</param>
        Task<List<BackgroundJobInfo>> GetWaitingJobsAsync(int maxResultCount);

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="jobInfo">Job information.</param>
        Task DeleteAsync(BackgroundJobInfo jobInfo);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="jobInfo">Job information.</param>
        Task UpdateAsync(BackgroundJobInfo jobInfo);
    }
}