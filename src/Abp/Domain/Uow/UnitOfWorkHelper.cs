using System.Reflection;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// UOW帮助类
    /// </summary>
    internal static class UnitOfWorkHelper
    {
        /// <summary>
        /// 是否具有UnitOfWorkAttribute属性.
        /// </summary>
        /// <param name="memberInfo">Method info to check</param>
        public static bool HasUnitOfWorkAttribute(MemberInfo memberInfo)
        {
            return memberInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
        }
    }
}