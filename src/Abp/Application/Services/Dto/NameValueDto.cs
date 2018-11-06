using System;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ����name value��ֵ�Ե�DTO�� nameΪstring���ͣ� valueΪ���ͻ�string����
    /// </summary>
    [Serializable]
    public class NameValueDto : NameValueDto<string>
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public NameValueDto()
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public NameValueDto(string name, string value)
            : base(name, value)
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="nameValue">A <see cref="NameValue"/> object to get it's name and value</param>
        public NameValueDto(NameValue nameValue)
            : this(nameValue.Name, nameValue.Value)
        {

        }
    }

    /// <summary>
    /// ����name value��ֵ�Ե�DTO�� nameΪstring���ͣ� valueΪ���ͻ�string����
    /// </summary>
    [Serializable]
    public class NameValueDto<T> : NameValue<T>
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public NameValueDto()
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public NameValueDto(string name, T value)
            : base(name, value)
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="nameValue">A <see cref="NameValue"/> object to get it's name and value</param>
        public NameValueDto(NameValue<T> nameValue)
            : this(nameValue.Name, nameValue.Value)
        {

        }
    }
}