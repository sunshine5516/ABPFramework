using System;

namespace Abp.Runtime.Validation
{
    /// <summary>
    /// ������ӵ������Զ���֤�ķ�����
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property)]
    public class DisableValidationAttribute : Attribute
    {
        
    }
}