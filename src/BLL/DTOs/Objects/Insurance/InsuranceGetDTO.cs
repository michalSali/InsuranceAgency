using BLL.DTOs.Objects.InsuranceOffer;
using BLL.DTOs.People.Client;
using System;

namespace BLL.DTOs.Objects.Insurance
{
    /// <summary>
    /// DTO used to get insurance
    /// </summary>
    public class InsuranceGetDTO : DTOBase
    {
        public ClientGetDTO Client { get; set; }

        public InsuranceOfferGetDTO InsuranceOffer { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public bool Approved { get; set; } = false;

        public bool Declined { get; set; } = false;
    }
}