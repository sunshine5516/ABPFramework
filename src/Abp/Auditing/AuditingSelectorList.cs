using System.Collections.Generic;

namespace Abp.Auditing
{
    /// <summary>
    /// NamedTypeSelector对象的集合
    /// </summary>
    internal class AuditingSelectorList : List<NamedTypeSelector>, IAuditingSelectorList
    {
        public bool RemoveByName(string name)
        {
            return RemoveAll(s => s.Name == name) > 0;
        }
    }
}