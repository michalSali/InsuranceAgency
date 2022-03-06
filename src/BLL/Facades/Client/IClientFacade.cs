using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.Objects.BackgroundInfo;
using BLL.DTOs.Objects.ClientConnection;
using BLL.DTOs.Objects.Gear;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.User;
using BLL.QueryObjects;

namespace BLL.Facades.Client
{
    public interface IClientFacade
    {
        Task<int> CreateNewAsync(int insuranceAgentId, UserCreateDTO entityUserInfoDto);
        
        Task<ClientGetDTO> GetAsync(int id);

        Task<ClientGetDTO> GetWithExtendedInfoAsync(int id);

        Task<ClientGetDTO> GetWithAllInfoAsync(int id);

        Task<ClientGetAggregatedDTO> GetAggregatedAsync(int id);

        Task<int> AddBackgroundInfoAsync(BackgroundInfoCreateDTO entityDto);
        
        Task<bool> UpdateBackgroundInfoAsync(BackgroundInfoUpdateDTO entityDto);
        
        Task<bool> DeleteBackgroundInfoAsync(int id);

        Task<BackgroundInfoGetDTO> GetBackgroundInfoAsync(int id);

        Task<int> AddGearAsync(GearCreateDTO entityDto);
        
        Task<bool> UpdateGearAsync(GearUpdateDTO entityDto);
        
        Task<bool> DeleteGearAsync(int id);

        Task<int> AddClientConnectionAsync(ClientConnectionCreateDTO entityDto);
        
        Task<bool> UpdateClientConnectionAsync(ClientConnectionUpdateDTO entityDto);
        
        Task<bool> DeleteClientConnectionAsync(int id);

        Task<ClientConnectionGetDTO> GetClientConnectionAsync(int id);

        Task<bool> ChangeAgentAsync(int clientId, int newAgentId);

        Task<IEnumerable<ClientGetDTO>> GetAllClientsAsync(
            bool extendedInfo = true, int? agentId = null, QueryPagingDTO? queryPagingDto = null);

        Task<IEnumerable<ClientGetAggregatedDTO>> GetAllClientsAggregatedAsync(
            int? agentId = null, QueryPagingDTO? queryPagingDto = null);
        
        Task<IEnumerable<ClientGetAggregatedDTO>> GetAllDirectorsClientsAggregatedAsync(
            int directorId, QueryPagingDTO? queryPagingDto = null);

    }
}