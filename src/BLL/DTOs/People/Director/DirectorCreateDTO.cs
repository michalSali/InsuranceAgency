using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.People.Director
{
    /// <summary>
    /// DTO used to create director
    /// </summary>
    public class DirectorCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        [StringLength(20)]
        [Required]
        public string Section { get; set; }
    }
}