using BLL.DTOs.Objects.Insurance;
using BLL.DTOs.People.Director;
using System;
using System.Collections.Generic;

namespace BLL.DTOs.Objects.InsuranceOffer
{
    /// <summary>
    /// DTO used to get insurance offer
    /// </summary>
    public class InsuranceOfferGetDTO : DTOBase
    {
        public DateTime CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string Description { get; set; }

        public virtual DirectorGetDTO Director { get; set; }
        public virtual ICollection<InsuranceGetDTO> Insurances { get; set; }
    }
}