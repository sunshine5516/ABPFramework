namespace Abp.Runtime.Validation
{
    /// <summary>
    /// 用于自定义Validation 规则. ABP默认的validation 规则是来自System.ComponentModel.DataAnnotations中的规则。
    /// 如果要添加自定义Validation 规则，需要实现ICustomValidate接口。
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