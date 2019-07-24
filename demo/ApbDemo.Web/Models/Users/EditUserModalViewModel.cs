using AbpDemo.Roles.Dto;
using AbpDemo.Users.Dto;
using System.Collections.Generic;
using System.Linq;

namespace AbpDemo.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            //return User.Roles != null && User.Roles.Any(r => r == role.DisplayName);
            return User.Roles != null && User.Roles.Any(r => r == role.Name);
        }
    }
}