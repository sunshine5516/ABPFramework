namespace Abp.BackgroundJobs
{
    /// <summary>
    /// 定义一个后台工作任务的接口
    /// </summary>
    public interface IBackgroundJob<in TArgs>
    {
        /// <summary>
        /// 执行工作
        /// </summary>
        /// <param name="args">参数.</param>
        void Execute(TArgs args);
    }
}