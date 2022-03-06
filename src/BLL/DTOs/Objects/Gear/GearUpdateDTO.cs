using BLL.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.Gear
{
    /// <summary>
    /// DTO used to update gear
    /// </summary>
    public class GearUpdateDTO : DTOBase
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