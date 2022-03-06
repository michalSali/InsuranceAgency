using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents client entity in database
    /// </summary>
    public class Client : BaseEntity
    {
        [ForeignKey(nameof(Id))]
        public virtual User User { get; set; }

        public int InsuranceAgentId { get; set; }

        [ForeignKey(nameof(InsuranceAgentId))]
        public virtual InsuranceAgent InsuranceAgent { get; set; }

        [InverseProperty("Object")]
        public virtual ICollection<ClientConnection> ObjectConnections { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<ClientConnection> SubjectConnections { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<BackgroundInfo> BackgroundInfos { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<ClientInsurance> ClientInsurances { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<ConflictInvolvement> ConflictInvolvements { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Gear> Gears { get; set; }
    }
}