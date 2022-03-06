using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.Conflict
{
    /// <summary>
    /// DTO used to create conflict
    /// </summary>
    public class ConflictCreateDTO
    {
        public string Location { get; set; }

        [StringLength(40)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime Beginning { get; set; }

        public DateTime? End { get; set; }

        public int DirectorId { get; set; }
    }
}