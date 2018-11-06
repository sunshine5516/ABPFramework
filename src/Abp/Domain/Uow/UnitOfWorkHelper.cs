using System.Reflection;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// UOW������
    /// </summary>
    internal static class UnitOfWorkHelper
    {
        /// <summary>
        /// �Ƿ����UnitOfWorkAttribute����.
        /// </summary>
        /// <param name="memberInfo">Method info to check</param>
        public static bool HasUnitOfWorkAttribute(MemberInfo memberInfo)
        {
            return memberInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
        }
    }
}