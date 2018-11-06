using System.Collections.Generic;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ��װ��һ��IReadOnlyList����
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="Items"/> list</typeparam>
    public interface IListResult<T>
    {
        /// <summary>
        /// List of items.
        /// </summary>
        IReadOnlyList<T> Items { get; set; }
    }
}