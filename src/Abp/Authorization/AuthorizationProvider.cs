using Abp.Dependency;

namespace Abp.Authorization
{
    /// <summary>
    /// ΪӦ�ó�����Ȩ�޵Ľӿڡ�
    /// ʵ�����Զ���ģ���Ȩ��.
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