using BLL.DTOs.Objects.BackgroundInfo;
using BLL.DTOs.Objects.Gear;
using BLL.DTOs.People.User;
using System.Collections.Generic;

namespace BLL.DTOs.People.Client
{
    /// <summary>
    /// DTO used to get client aggregated
    /// </summary>
    public class ClientGetAggregatedDTO : DTOBase
    {
        public UserInfoDTO UserInfo { get; set; }

        public int ActiveConflicts { get; set; }

        public int TotalConflicts { get; set; }

        public int TotalBalanceRecord { get; set; }

        public int ActiveInsurances { get; set; }

        public int TotalInsurances { get; set; }

        public int ConnectionCount { get; set; }

        public ICollection<GearGetDTO> Gears { get; set; }

        public ICollection<BackgroundInfoGetDTO> BackgroundInfos { get; set; }
    }
}