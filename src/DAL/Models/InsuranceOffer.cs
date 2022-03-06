using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents insurance offer entity in database
    /// </summary>
    public class InsuranceOffer : BaseEntity
    {
        
        public DateTime CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        public int DirectorId { get; set; }

        [ForeignKey(nameof(DirectorId))]
        public virtual Director Director { get; set; }

        [InverseProperty("InsuranceOffer")]
        public virtual ICollection<ClientInsurance> ClientInsurances { get; set; }
    }
}