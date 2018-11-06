namespace Abp.Dependency
{
    /// <summary>
    /// 依赖注入接口
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface IConventionalDependencyRegistrar
    {
        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="context">Registration context</param>
        void RegisterAssembly(IConventionalRegistrationContext context);
    }
}