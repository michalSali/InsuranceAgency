using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.Objects.InsuranceOffer;
using BLL.DTOs.People.InsuranceAgent;
using BLL.DTOs.People.User;
using System.Collections.Generic;

namespace BLL.DTOs.People.Director
{
    /// <summary>
    /// DTO used to get director
    /// </summary>
    public class DirectorGetDTO : DTOBase
    {
        public UserInfoDTO UserInfo { get; set; }

        public string Section { get; set; }

        public ICollection<InsuranceOfferGetDTO> InsuranceOffers { get; set; }

        public ICollection<InsuranceAgentGetDTO> InsuranceAgents { get; set; }

        public ICollection<ConflictGetDTO> Conflicts { get; set; }
    }
}