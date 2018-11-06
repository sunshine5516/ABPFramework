using System.Collections.Generic;

namespace Abp.Application.Navigation
{
    /// <summary>
    /// 在应用程序中管理导航接口。
    /// 这个接口封装了一个字典类型的Menus和MenuDefinition类型的MainMenu
    /// </summary>
    public interface INavigationManager
    {
        /// <summary>
        /// All menus defined in the application.
        /// </summary>
        IDictionary<string, MenuDefinition> Menus { get; }

        /// <summary>
        /// Gets the main menu of the application.
        /// A shortcut of <see cref="Menus"/>["MainMenu"].
        /// </summary>
        MenuDefinition MainMenu { get; }
    }
}
