namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ��װ��TotalCount����
    /// </summary>
    public interface IHasTotalCount
    {
        /// <summary>
        /// ����
        /// </summary>
        int TotalCount { get; set; }
    }
}