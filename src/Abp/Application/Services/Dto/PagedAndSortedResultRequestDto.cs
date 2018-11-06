using System;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ʵ�� <see cref="IPagedAndSortedResultRequest"/>.��ҳ����ӿ�
    /// </summary>
    [Serializable]
    public class PagedAndSortedResultRequestDto : PagedResultRequestDto, IPagedAndSortedResultRequest
    {
        public virtual string Sorting { get; set; }
    }
}