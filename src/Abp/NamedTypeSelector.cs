using System;

namespace Abp
{
    /// <summary>
    /// ����ѡ�������������ĺ���������һ����typeΪ�������������bool���͵�ί��predicate
    /// </summary>
    public class NamedTypeSelector
    {
        /// <summary>
        /// Name of the selector.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Predicate.
        /// </summary>
        public Func<Type, bool> Predicate { get; set; }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="predicate">Predicate</param>
        public NamedTypeSelector(string name, Func<Type, bool> predicate)
        {
            Name = name;
            Predicate = predicate;
        }
    }
}