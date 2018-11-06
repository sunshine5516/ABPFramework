using System;
using System.Collections.Generic;
namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ʵ��<see cref="IPagedResult{T}"/>�ӿ�.
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="ListResultDto{T}.Items"/> list</typeparam>
    [Serializable]
    public class PagedResultDto<T> : ListResultDto<T>, IPagedResult<T>
    {
        /// <summary>
        /// ����.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// ���캯��
        /// </summary>
        public PagedResultDto()
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="totalCount">����</param>
        /// <param name="items"></param>
        public PagedResultDto(int totalCount, IReadOnlyList<T> items)
            : base(items)
        {
            TotalCount = totalCount;
        }
    }
}