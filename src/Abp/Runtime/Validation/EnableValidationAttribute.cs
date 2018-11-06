using System;

namespace Abp.Runtime.Validation
{
    /// <summary>
    /// 可以添加到一个方法来启用自动验证，如果验证被禁。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class EnableValidationAttribute : Attribute
    {

    }
}