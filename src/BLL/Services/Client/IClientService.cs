using BLL.DTOs.People.Client;
using BLL.QueryObjects;
using System.Threading.Tasks;

namespace BLL.Services.Client
{
    /// <summary>
    /// Interface for client service
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Creates new client
        /// </summary>
        /// <param name="entityDto"> client create DTO</param>
        /// <returns> id of new client, -1 if failed</returns>
        Task<int> CreateAsync(ClientCreateDTO entityDto);

        /// <summary>
        /// Deletes client by id
        /// </summary>
        /// <param name="id"> id of client in db </param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Updates client
        /// </summary>
        /// <param name="entityDto"> client update DTO</param>
        Task UpdateAsync(ClientUpdateDTO entityDto);

        #region Get
        
        /// <summary>
        /// Get client only with user info included
        /// </summary>
        /// <param name="id"> id of client in db</param>
        /// <returns>client get DTO, null if not found</returns>
        Task<ClientGetDTO> GetAsync(int id);
        
        /// <summary>
        /// Gets client by id with extended info (connections, bginfo, gear) included
        /// </summary>
        /// <param name="id">id of client in db</param>
        /// <returns>client get DTO, null if not found</returns>
        Task<ClientGetDTO> GetWithExtendedInfoAsync(int id);
        
        /// <summary>
        /// Get user with all info included (connections, bginfo, gear, conflicts, insurances)
        /// </summary>
        /// <param name="id"> id to find client by in db</param>
        /// <returns>client get DTO, null if not found</returns>
        Task<ClientGetDTO> GetWithAllInfoAsync(int id);
        
        /// <summary>
        /// Get client with all info aggregated into a summary statistics
        /// </summary>
        /// <param name="id"> id of client to find </param>
        /// <returns> client get aggregated DTO, null if not found </returns>
        Task<ClientGetAggregatedDTO> GetWithAllInfoAggregatedAsync(int id);

        #endregion Get

        #region Get for all
        
        /// <summary>
        /// Get all clients with only user info included
        /// </summary>
        /// <param name="insuranceAgentId"> optional insurance agent id to filter on</param>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns>query result with client get DTOs</returns>
        Task<QueryResultDTO<ClientGetDTO>> GetAllAsync(int? insuranceAgentId = null,
            QueryPagingDTO? queryPagingDto = null);
        
        /// <summary>
        /// Get all clients with extended info (connections, bginfo, gear) included
        /// </summary>
        /// <param name="insuranceAgentId"> optional agent id to filter on</param>
        /// <param name="queryPagingDto"> optional paging</param>
        /// <returns>query result with client get DTOs</returns>
        Task<QueryResultDTO<ClientGetDTO>> GetAllWithExtendedInfoAsync(int? insuranceAgentId = null,
            QueryPagingDTO? queryPagingDto = null);
        
        /// <summary>
        /// Get all clients with all information included (connections, bginfo, gear, conflicts, insurances)
        /// </summary>
        /// <param name="insuranceAgentId"> optional insurance agent id to filter on</param>
        /// <param name="queryPagingDto"> optional query paging</param>
        /// <returns>query result with client get DTOs</returns>
        Task<QueryResultDTO<ClientGetDTO>> GetAllWithAllInfoAsync(int? insuranceAgentId = null,
            QueryPagingDTO? queryPagingDto = null);

        /// <summary>
        /// Get all clients with all information included (connections, bginfo, gear, conflicts, insurances) for director
        /// </summary>
        /// <param name="directorId"> director id to filter on</param>
        /// <param name="queryPagingDto"> optional paging</param>
        /// <returns> query result with client get DTOs</returns>
        Task<QueryResultDTO<ClientGetDTO>> GetAllWithAllInfoByDirectorAsync(int directorId,
            QueryPagingDTO? queryPagingDto = null);
        
        /// <summary>
        /// Get all clients with all information included (connections, bginfo, gear, conflicts, insurances)
        /// aggregated into a summary statistics
        /// </summary>
        /// <param name="insuranceAgentId"> optional agent id to filter on</param>
        /// <param name="queryPagingDto">optional paging</param>
        /// <returns> query result with client get aggregated DTOs</returns>
        Task<QueryResultDTO<ClientGetAggregatedDTO>> GetAllWithAllInfoAggregatedAsync(int? insuranceAgentId = null,
            QueryPagingDTO? queryPagingDto = null);
        
        /// <summary>
        /// Gets all clients aggregated by director id
        /// </summary>
        /// <param name="directorId"> director id to filter on</param>
        /// <param name="queryPagingDto">optional paging</param>
        /// <returns>query result with all aggregated get DTOs</returns>
        Task<QueryResultDTO<ClientGetAggregatedDTO>> GetAllWithAllInfoAggregatedByDirectorAsync(int directorId,
            QueryPagingDTO? queryPagingDto = null);

        #endregion Get for all
    }
}