using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.People.Director
{
    /// <summary>
    /// DTO used to update director
    /// </summary>
    public class DirectorUpdateDTO : DTOBase
    {
        [StringLength(20)]
        [Required]
        public string Section { get; set; }
    }
}