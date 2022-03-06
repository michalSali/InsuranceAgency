using DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents gear entity in database
    /// </summary>
    public class Gear : BaseEntity
    {
        [Required]
        public string Name;

        public GearType Type { get; set; }

        public int Value { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }
    }
}