using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.ConflictInvolvement
{
    /// <summary>
    /// DTO used to create conflict involvement
    /// </summary>
    public class ConflictInvolvementCreateDTO
    {
        [Required]
        public int ConflictId { get; set; }

        [Required]
        public int ClientId { get; set; }
    }
}