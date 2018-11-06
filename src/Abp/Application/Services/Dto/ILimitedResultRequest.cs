namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// This interface is defined to standardize to request a limited result.
    /// </summary>
    public interface ILimitedResultRequest
    {
        /// <summary>
        /// 最大结果数量
        /// </summary>
        int MaxResultCount { get; set; }
    }
}