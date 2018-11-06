namespace Abp.Runtime.Validation
{
    /// <summary>
    /// This interface is used to normalize inputs before method execution.
    /// </summary>
    public interface IShouldNormalize
    {
        /// <summary>
        /// �÷���������Validation ��ʹ��ǰ����DTO�����Ĵ���
        /// </summary>
        void Normalize();
    }
}