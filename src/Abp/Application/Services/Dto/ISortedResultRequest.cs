namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ��׼�������������ӿ�
    /// </summary>
    public interface ISortedResultRequest
    {
        /// <summary>
        /// ������Ϣ.
        /// Ӧ�ð��������ֶκ�����ʽ��ASC��DESC��
        /// ���԰�������Զ��ţ������ָ����ֶΡ�
        /// </summary>
        /// <example>
        /// Examples:
        /// "Name"
        /// "Name DESC"
        /// "Name ASC, Age DESC"
        /// </example>
        string Sorting { get; set; }
    }
}