using System;

namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// ��װ��CreationTime
    /// �ڽ�<see cref ='Entity'/>���浽���ݿ�ʱ�Զ����á�
    /// </summary>
    public interface IHasCreationTime
    {
        /// <summary>
        /// ��������
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}