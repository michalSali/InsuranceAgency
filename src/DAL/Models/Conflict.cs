using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents conflict entity in database
    /// </summary>
    public class Conflict : BaseEntity
    {
        public string Location { get; set; }
 
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTime Beginning { get; set; }

        public DateTime? End { get; set; }

        [InverseProperty("Conflict")]
        public virtual ICollection<ConflictInvolvement> ConflictInvolvements { get; set; }

        public int DirectorId { get; set; }

        [ForeignKey(nameof(DirectorId))]
        public virtual Director Director { get; set; }
    }
}