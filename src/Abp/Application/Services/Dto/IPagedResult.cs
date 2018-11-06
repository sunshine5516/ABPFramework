namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// 定义为标准化一组项返回给客户端接口。
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="IListResult{T}.Items"/> list</typeparam>
    public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
    {

    }
}