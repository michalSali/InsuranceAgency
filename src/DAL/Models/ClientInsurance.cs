using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents an insurance of a client (contracted offer) as an entity in database
    /// </summary>
    public class ClientInsurance : BaseEntity
    {
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }

        public int InsuranceOfferId { get; set; }

        [ForeignKey(nameof(InsuranceOfferId))]
        public virtual InsuranceOffer InsuranceOffer { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public bool Approved { get; set; } = false;

        public bool Declined { get; set; } = false;
    }
}