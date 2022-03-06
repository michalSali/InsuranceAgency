using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents insurance agent entity in database
    /// </summary>
    public class InsuranceAgent : BaseEntity
    {
        public int DirectorId { get; set; }

        [ForeignKey(nameof(DirectorId))]
        public virtual Director Director { get; set; }

        [ForeignKey(nameof(Id))]
        public virtual User User { get; set; }

        [InverseProperty("InsuranceAgent")]
        public virtual ICollection<Client> Clients { get; set; }
    }
}