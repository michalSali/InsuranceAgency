using BLL.DTOs.Enums;
using System;

namespace BLL.DTOs.People.User
{
    /// <summary>
    /// DTO that is used to display user info
    /// </summary>
    public class UserInfoDTO : DTOBase
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birth { get; set; }
        
        public UserRoleDTO Role { get; set; }
    }
}