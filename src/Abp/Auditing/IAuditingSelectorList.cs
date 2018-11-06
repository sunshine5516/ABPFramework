using System.Collections.Generic;

namespace Abp.Auditing
{
    /// <summary>
    /// NamedTypeSelector对象的集合
    /// </summary>
    public interface IAuditingSelectorList : IList<NamedTypeSelector>
    {
        /// <summary>
        /// Removes a selector by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool RemoveByName(string name);
    }
}