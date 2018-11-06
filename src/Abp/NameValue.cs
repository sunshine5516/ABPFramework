using System;

namespace Abp
{
    /// <summary>
    /// ����name value��ֵ�Ե�DTO�� nameΪstring���ͣ� valueΪ���ͻ�string����
    /// </summary>
    [Serializable]
    public class NameValue : NameValue<string>
    {
        /// <summary>
        /// Creates a new <see cref="NameValue"/>.
        /// </summary>
        public NameValue()
        {

        }

        /// <summary>
        /// Creates a new <see cref="NameValue"/>.
        /// </summary>
        public NameValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    /// <summary>
    /// ����name value��ֵ�Ե�DTO�� nameΪstring���ͣ� valueΪ���ͻ�string����
    /// </summary>
    [Serializable]
    public class NameValue<T>
    {
        /// <summary>
        /// ����.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ֵ.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Creates a new <see cref="NameValue"/>.
        /// </summary>
        public NameValue()
        {

        }

        /// <summary>
        /// Creates a new <see cref="NameValue"/>.
        /// </summary>
        public NameValue(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }
}