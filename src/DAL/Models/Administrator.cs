using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents administrator entity in DB.
    /// </summary>
    public class Administrator : BaseEntity
    {
        [ForeignKey(nameof(Id))]
        public virtual User User { get; set; }
    }
}