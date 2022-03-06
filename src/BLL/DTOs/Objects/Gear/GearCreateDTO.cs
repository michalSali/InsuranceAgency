using BLL.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.Gear
{
    /// <summary>
    /// DTO used to create gear
    /// </summary>
    public class GearCreateDTO
    {
        [StringLength(30)]
        [Required]
        public string Name;

        public GearType Type { get; set; }

        public int Value { get; set; }

        [Required]
        public int ClientId { get; set; }
    }
}