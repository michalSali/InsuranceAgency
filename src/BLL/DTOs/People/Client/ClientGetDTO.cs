using BLL.DTOs.Objects.BackgroundInfo;
using BLL.DTOs.Objects.ClientConnection;
using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.Objects.Gear;
using BLL.DTOs.Objects.Insurance;
using BLL.DTOs.People.InsuranceAgent;
using BLL.DTOs.People.User;
using System.Collections.Generic;

namespace BLL.DTOs.People.Client
{
    /// <summary>
    /// DTO used to get client
    /// </summary>
    public class ClientGetDTO : DTOBase
    {
        public UserInfoDTO UserInfo { get; set; }

        public InsuranceAgentGetDTO InsuranceAgentInfo { get; set; }

        public ICollection<ClientConnectionGetDTO> Connections { get; set; }

        public ICollection<GearGetDTO> Gears { get; set; }

        public ICollection<BackgroundInfoGetDTO> BackgroundInfos { get; set; }

        public ICollection<InsuranceGetDTO> Insurances { get; set; }

        public ICollection<ConflictGetDTO> Conflicts { get; set; }
    }
}