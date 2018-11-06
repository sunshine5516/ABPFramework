using Abp.Dependency;

namespace Abp.Application.Navigation
{
    /// <summary>
    /// 由改变应用程序导航的类来实现。
    /// 用于设置NavigationManager的Menus和MainMenu（通过 INavigationProviderContext对象访问NavigationManager）。
    /// </summary>
    public abstract class NavigationProvider : ITransientDependency
    {
        /// <summary>
        /// Used to set navigation.
        /// </summary>
        /// <param name="context">Navigation context</param>
        public abstract void SetNavigation(INavigationProviderContext context);
    }
}