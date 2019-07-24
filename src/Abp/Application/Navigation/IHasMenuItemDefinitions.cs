using System.Collections.Generic;

namespace Abp.Application.Navigation
{
    /// <summary>
    /// 为具有菜单项的类声明通用接口。
    /// </summary>
    public interface IHasMenuItemDefinitions
    {
        /// <summary>
        /// List of menu items.
        /// </summary>
        IList<MenuItemDefinition> Items { get; }
    }
}