using System;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// 声明对象的多租户属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Interface)]
    public class MultiTenancySideAttribute : Attribute
    {
        /// <summary>
        /// 多租户方
        /// </summary>
        public MultiTenancySides Side { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="side">Multitenancy side.</param>
        public MultiTenancySideAttribute(MultiTenancySides side)
        {
            Side = side;
        }
    }
}