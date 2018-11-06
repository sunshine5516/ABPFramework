namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// This interface is defined to standardize to request a limited result.
    /// </summary>
    public interface ILimitedResultRequest
    {
        /// <summary>
        /// ���������
        /// </summary>
        int MaxResultCount { get; set; }
    }
}