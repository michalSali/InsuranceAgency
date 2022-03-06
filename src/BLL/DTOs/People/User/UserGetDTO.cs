using BLL.DTOs.Enums;
using BLL.DTOs.People.Administrator;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.InsuranceAgent;
using System;

namespace BLL.DTOs.People.User
{
    /// <summary>
    /// DTO that is used to get user with hashed password, should not be used on frontend
    /// instead use <see cref="UserInfoDTO"/>
    /// </summary>
    public class UserGetDTO : DTOBase
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birth { get; set; }

        public string PasswordHash { get; set; }
        
        public UserRoleDTO Role { get; set; }
    }
}