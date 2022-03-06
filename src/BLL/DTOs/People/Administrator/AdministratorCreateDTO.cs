using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.People.Administrator
{
    /// <summary>
    /// DTO used to create administrator
    /// </summary>
    public class AdministratorCreateDTO
    {
        [Required]
        public int UserId { get; set; }
    }
}