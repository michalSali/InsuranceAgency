using System;
using System.ComponentModel.DataAnnotations;
using BLL.DTOs.Enums;

namespace BLL.DTOs.People.User
{
    /// <summary>
    /// DTO that is used for user registration
    /// </summary>
    public class UserRegisterDTO
    {
        [Required]
        [StringLength(32, ErrorMessage = "Name length can't be more than 8.")]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime Birth { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long and shorter than 30 characters.", MinimumLength = 8)]
        public string Password { get; set; }
        
        [Required]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
    }
}