namespace Abp.Domain.Uow
{
    /// <summary>
    /// ����Ҫ���ݿ�����ʱ��ȡ�����ַ�����
    /// </summary>
    public interface IConnectionStringResolver
    {
        /// <summary>
        /// ��ȡ�ַ�������
        /// </summary>
        /// <param name="args">�����ַ�������.</param>
        string GetNameOrConnectionString(ConnectionStringResolveArgs args);
    }
}