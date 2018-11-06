namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// 为标准化以请求分页结果接口。
    /// </summary>
    public interface IPagedResultRequest : ILimitedResultRequest
    {
        /// <summary>
        /// Skip count (beginning of the page).
        /// </summary>
        int SkipCount { get; set; }
    }
}