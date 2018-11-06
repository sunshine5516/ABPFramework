using System;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// 用于combobox/list中Item的DTO
    /// </summary>
    [Serializable]
    public class ComboboxItemDto
    {
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ComboboxItemDto()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="displayText">名称</param>
        public ComboboxItemDto(string value, string displayText)
        {
            Value = value;
            DisplayText = displayText;
        }
    }
}