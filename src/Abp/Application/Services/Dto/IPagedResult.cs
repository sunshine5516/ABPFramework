namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ����Ϊ��׼��һ����ظ��ͻ��˽ӿڡ�
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="IListResult{T}.Items"/> list</typeparam>
    public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
    {

    }
}