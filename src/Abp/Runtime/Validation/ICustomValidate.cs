namespace Abp.Runtime.Validation
{
    /// <summary>
    /// �����Զ���Validation ����. ABPĬ�ϵ�validation ����������System.ComponentModel.DataAnnotations�еĹ���
    /// ���Ҫ����Զ���Validation ������Ҫʵ��ICustomValidate�ӿڡ�
    /// </summary>
    public interface ICustomValidate
    {
        /// <summary>
        /// This method is used to validate the object.
        /// </summary>
        /// <param name="context">Validation context.</param>
        void AddValidationErrors(CustomValidationContext context);
    }
}