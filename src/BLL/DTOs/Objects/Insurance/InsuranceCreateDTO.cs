using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.Insurance
{
    /// <summary>
    /// DTO used to create insurance
    /// </summary>
    public class InsuranceCreateDTO
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int InsuranceOfferId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public bool Approved { get; set; } = false;

        public bool Declined { get; set; } = false;
    }
}