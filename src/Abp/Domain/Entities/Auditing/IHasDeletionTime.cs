using System;

namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// ��װ��DeletionTime
    /// </summary>
    public interface IHasDeletionTime : ISoftDelete
    {
        /// <summary>
        /// ɾ��ʱ��
        /// </summary>
        DateTime? DeletionTime { get; set; }
    }
}