using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents conflict involvement entity used to join client with conflict in database
    /// </summary>
    public class ConflictInvolvement : BaseEntity
    {
        public int ClientId { get; set; }

        public int ConflictId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(ConflictId))]
        public virtual Conflict Conflict { get; set; }

        [InverseProperty("ConflictInvolvement")]
        public virtual ICollection<ConflictRecord> ConflictRecords { get; set; }
    }
}