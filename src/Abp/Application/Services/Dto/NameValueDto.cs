using System;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// 用于name value键值对的DTO， name为string类型， value为泛型或string类型
    /// </summary>
    [Serializable]
    public class NameValueDto : NameValueDto<string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public NameValueDto()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public NameValueDto(string name, string value)
            : base(name, value)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nameValue">A <see cref="NameValue"/> object to get it's name and value</param>
        public NameValueDto(NameValue nameValue)
            : this(nameValue.Name, nameValue.Value)
        {

        }
    }

    /// <summary>
    /// 用于name value键值对的DTO， name为string类型， value为泛型或string类型
    /// </summary>
    [Serializable]
    public class NameValueDto<T> : NameValue<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public NameValueDto()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public NameValueDto(string name, T value)
            : base(name, value)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nameValue">A <see cref="NameValue"/> object to get it's name and value</param>
        public NameValueDto(NameValue<T> nameValue)
            : this(nameValue.Name, nameValue.Value)
        {

        }
    }
}