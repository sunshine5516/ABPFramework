using System.Globalization;

namespace Abp.Localization
{
    /// <summary>
    /// 封装language的基本信息
    /// </summary>
    public class LanguageInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 展示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 图标.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 是否是默认
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// Is this language Right To Left?
        /// </summary>
        public bool IsRightToLeft
        {
            get
            {
                try
                {
                    return CultureInfo.GetCultureInfo(Name).TextInfo?.IsRightToLeft ?? false;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">
        /// Code name of the language.
        /// It should be valid culture code.
        /// Ex: "en-US" for American English, "tr-TR" for Turkey Turkish.
        /// </param>
        /// <param name="displayName">
        /// Display name of the language in it's original language.
        /// Ex: "English" for English, "T黵k鏴" for Turkish.
        /// </param>
        /// <param name="icon">An icon can be set to display on the UI</param>
        /// <param name="isDefault">Is this the default language?</param>
        /// <param name="isDisabled">Is this the language disabled?</param>
        public LanguageInfo(string name, string displayName, string icon = null, bool isDefault = false, bool isDisabled = false)
        {
            Name = name;
            DisplayName = displayName;
            Icon = icon;
            IsDefault = isDefault;
            IsDisabled = isDisabled;
        }
    }
}