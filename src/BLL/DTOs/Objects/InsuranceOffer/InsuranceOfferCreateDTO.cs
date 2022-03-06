using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.InsuranceOffer
{
    /// <summary>
    /// DTO used to create insurance offer
    /// </summary>
    public class InsuranceOfferCreateDTO
    {
        public DateTime CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        [Required]
        public int DirectorId { get; set; }
    }
}