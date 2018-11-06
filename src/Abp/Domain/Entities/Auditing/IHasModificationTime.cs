using System;

namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// �������洢��ʵ���<see cref ="LastModificationTime"/>��ʵ�����ʵ�ִ˽ӿڡ�
    /// �ýӿڷ�װ������޸ĵ�ʱ��
    /// </summary>
    public interface IHasModificationTime
    {
        /// <summary>
        /// ����޸�����
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}