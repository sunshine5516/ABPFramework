using Abp.Dependency;

namespace Abp.Authorization
{
    /// <summary>
    /// 为应用程序定义权限的接口。
    /// 实现它以定义模块的权限.
    /// </summary>
    public abstract class AuthorizationProvider : ITransientDependency
    {
        /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public abstract void SetPermissions(IPermissionDefinitionContext context);
    }
}