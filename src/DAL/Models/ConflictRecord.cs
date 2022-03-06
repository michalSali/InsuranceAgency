using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents conflict record entity in database
    /// </summary>
    public class ConflictRecord : BaseEntity
    {
        public DateTime Date { get; set; }

        public int BalanceChange { get; set; }
        
        public string Description { get; set; }

        public int ConflictInvolvementId { get; set; }

        [ForeignKey(nameof(ConflictInvolvementId))]
        public ConflictInvolvement ConflictInvolvement { get; set; }
    }
}