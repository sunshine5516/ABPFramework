using System;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// ��������Ķ��⻧����
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Interface)]
    public class MultiTenancySideAttribute : Attribute
    {
        /// <summary>
        /// ���⻧��
        /// </summary>
        public MultiTenancySides Side { get; set; }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="side">Multitenancy side.</param>
        public MultiTenancySideAttribute(MultiTenancySides side)
        {
            Side = side;
        }
    }
}