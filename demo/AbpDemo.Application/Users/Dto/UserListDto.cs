using AbpDemo.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbpDemo.Users.Dto
{
    public class UserListDto
    {
        public IList<UserDto> userListDto = new List<UserDto>(); 

    }
}