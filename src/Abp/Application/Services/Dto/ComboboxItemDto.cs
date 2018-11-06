using System;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ����combobox/list��Item��DTO
    /// </summary>
    [Serializable]
    public class ComboboxItemDto
    {
        /// <summary>
        /// ֵ
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// �Ƿ�ѡ��
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// ���캯��
        /// </summary>
        public ComboboxItemDto()
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="displayText">����</param>
        public ComboboxItemDto(string value, string displayText)
        {
            Value = value;
            DisplayText = displayText;
        }
    }
}