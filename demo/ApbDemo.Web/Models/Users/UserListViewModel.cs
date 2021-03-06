﻿using AbpDemo.Roles.Dto;
using AbpDemo.Users.Dto;
using System.Collections.Generic;

namespace AbpDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}