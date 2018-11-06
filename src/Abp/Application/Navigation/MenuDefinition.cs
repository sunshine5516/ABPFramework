using System;
using System.Collections.Generic;
using Abp.Localization;

namespace Abp.Application.Navigation
{
    /// <summary>
    /// 封装了导航栏上的主菜单的属性。
    /// ABP通过MenuDefinition/MenuItemDefinition构成了完整的系统菜单集合（超集）。
    /// 而UserMenu/UserMenuItem只构成用户所能访问的菜单集合，并且其DisplayName是本地化以后的DisplayName
    /// </summary>
    public class MenuDefinition : IHasMenuItemDefinitions
    {
        /// <summary>
        /// 唯一名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 显示名称.
        /// </summary>
        public ILocalizableString DisplayName { get; set; }

        /// <summary>
        /// 可用于存储与此菜单相关的自定义对象。 可选的。
        /// </summary>
        public object CustomData { get; set; }

        /// <summary>
        /// 菜单项目（第一级）。
        /// </summary>
        public IList<MenuItemDefinition> Items { get; set; }

        /// <summary>
        /// Creates a new <see cref="MenuDefinition"/> object.
        /// </summary>
        /// <param name="name">Unique name of the menu</param>
        /// <param name="displayName">Display name of the menu</param>
        /// <param name="customData">Can be used to store a custom object related to this menu.</param>
        public MenuDefinition(string name, ILocalizableString displayName, object customData = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Menu name can not be empty or null.");
            }

            if (displayName == null)
            {
                throw new ArgumentNullException("displayName", "Display name of the menu can not be null.");
            }

            Name = name;
            DisplayName = displayName;
            CustomData = customData;

            Items = new List<MenuItemDefinition>();
        }

        /// <summary>
        /// Adds a <see cref="MenuItemDefinition"/> to <see cref="Items"/>.
        /// </summary>
        /// <param name="menuItem"><see cref="MenuItemDefinition"/> to be added</param>
        /// <returns>This <see cref="MenuDefinition"/> object</returns>
        public MenuDefinition AddItem(MenuItemDefinition menuItem)
        {
            Items.Add(menuItem);
            return this;
        }
    }
}
