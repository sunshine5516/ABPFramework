namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// 标准化请求排序结果接口
    /// </summary>
    public interface ISortedResultRequest
    {
        /// <summary>
        /// 排序信息.
        /// 应该包括排序字段和排序方式（ASC或DESC）
        /// 可以包含多个以逗号（，）分隔的字段。
        /// </summary>
        /// <example>
        /// Examples:
        /// "Name"
        /// "Name DESC"
        /// "Name ASC, Age DESC"
        /// </example>
        string Sorting { get; set; }
    }
}