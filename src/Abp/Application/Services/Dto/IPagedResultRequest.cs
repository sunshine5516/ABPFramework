namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// Ϊ��׼���������ҳ����ӿڡ�
    /// </summary>
    public interface IPagedResultRequest : ILimitedResultRequest
    {
        /// <summary>
        /// Skip count (beginning of the page).
        /// </summary>
        int SkipCount { get; set; }
    }
}