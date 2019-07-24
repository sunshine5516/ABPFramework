using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// <see cref="IPermissionDependency"/>最简单的实现.
    /// 检查是否有一个或多个权限.
    /// </summary>
    public class SimplePermissionDependency : IPermissionDependency
    {
        /// <summary>
        /// 待检测的权限集合.
        /// </summary>
        public string[] Permissions { get; set; }

        /// <summary>
        /// 如果为true, all of the <see cref="Permissions"/> must be granted.
        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
        /// Default: false.
        /// </summary>
        public bool RequiresAll { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="permissions">The permissions.</param>
        public SimplePermissionDependency(params string[] permissions)
        {
            Permissions = permissions;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requiresAll">
        /// If this is set to true, all of the <see cref="Permissions"/> must be granted.
        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
        /// </param>
        /// <param name="permissions">The permissions.</param>
        public SimplePermissionDependency(bool requiresAll, params string[] permissions)
            : this(permissions)
        {
            RequiresAll = requiresAll;
        }

        /// <inheritdoc/>
        public Task<bool> IsSatisfiedAsync(IPermissionDependencyContext context)
        {
            return context.User != null
                ? context.PermissionChecker.IsGrantedAsync(context.User, RequiresAll, Permissions)
                : context.PermissionChecker.IsGrantedAsync(RequiresAll, Permissions);
        }
    }
}
