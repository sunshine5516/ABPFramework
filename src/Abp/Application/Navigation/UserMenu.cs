using System.Collections.Generic;
using Abp.Localization;

namespace Abp.Application.Navigation
{
    /// <summary>
    /// 封装了用于显示给用户的菜单
    /// </summary>
    public class UserMenu
    {
        /// <summary>
        /// 唯一名称 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A custom object related to this menu item.
        /// </summary>
        public object CustomData { get; set; }

        /// <summary>
        /// 菜单项目（第一级）。
        /// </summary>
        public IList<UserMenuItem> Items { get; set; }

        /// <summary>
        /// Creates a new <see cref="UserMenu"/> object.
        /// </summary>
        public UserMenu()
        {
            
        }

        /// <summary>
        /// Creates a new <see cref="UserMenu"/> object from given <see cref="MenuDefinition"/>.
        /// </summary>
        internal UserMenu(MenuDefinition menuDefinition, ILocalizationContext localizationContext)
        {
            Name = menuDefinition.Name;
            DisplayName = menuDefinition.DisplayName.Localize(localizationContext);
            CustomData = menuDefinition.CustomData;
            Items = new List<UserMenuItem>();
        }
    }
}