using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.ClientConnection
{
    /// <summary>
    /// DTO used for update of client connection
    /// </summary>
    public class ClientConnectionUpdateDTO : DTOBase
    {
        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        [Required]
        public int ObjectId { get; set; }

        [Required]
        public int SubjectId { get; set; }
    }
}