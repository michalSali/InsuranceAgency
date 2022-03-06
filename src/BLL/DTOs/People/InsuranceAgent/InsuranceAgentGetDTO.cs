using BLL.DTOs.People.Client;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.User;
using System.Collections.Generic;

namespace BLL.DTOs.People.InsuranceAgent
{
    /// <summary>
    /// DTO used to get insurance agent
    /// </summary>
    public class InsuranceAgentGetDTO : DTOBase
    {
        public DirectorGetDTO Director { get; set; }

        public ICollection<ClientGetDTO> Clients { get; set; }

        public UserInfoDTO UserInfo { get; set; }
    }
}