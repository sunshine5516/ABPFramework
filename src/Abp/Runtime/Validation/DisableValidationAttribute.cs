using System;

namespace Abp.Runtime.Validation
{
    /// <summary>
    /// 可以添加到禁用自动验证的方法。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property)]
    public class DisableValidationAttribute : Attribute
    {
        
    }
}