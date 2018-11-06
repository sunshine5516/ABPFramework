using Abp.Authorization;
using AbpDemo.Authorization.Roles;
using AbpDemo.Authorization.Users;

namespace AbpDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
