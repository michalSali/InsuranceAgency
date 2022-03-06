using BLL.DTOs.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.People.User
{
    /// <summary>
    /// DTO used to create user with hashed password
    /// </summary>
    public class UserCreateDTO
    {
        [StringLength(32, ErrorMessage = "Name length can't be more than 8.")]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime Birth { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}