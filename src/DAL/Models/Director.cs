using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents director entity in database
    /// </summary>
    public class Director : BaseEntity
    {
        [ForeignKey(nameof(Id))]
        public virtual User User { get; set; }

        public string Section { get; set; }

        [InverseProperty("Director")]
        public virtual ICollection<InsuranceOffer> InsuranceOffers { get; set; }

        [InverseProperty("Director")]
        public virtual ICollection<InsuranceAgent> InsuranceAgents { get; set; }

        [InverseProperty("Director")]
        public virtual ICollection<Conflict> Conflicts { get; set; }
    }
}