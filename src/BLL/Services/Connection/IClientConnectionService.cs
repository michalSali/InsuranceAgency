using BLL.DTOs.Objects.ClientConnection;
using BLL.QueryObjects;
using System.Threading.Tasks;
using BLL.QueryObjects.Filters;

namespace BLL.Services.Connection
{
    /// <summary>
    /// Interface for client connection service
    /// </summary>
    public interface IClientConnectionService
    {
        /// <summary>
        /// Creates new client connection
        /// </summary>
        /// <param name="entityDto"> client connection create DTO</param>
        /// <returns> id of new connection, -1 if failed</returns>
        Task<int> CreateAsync(ClientConnectionCreateDTO entityDto);

        /// <summary>
        /// Gets client connection by id
        /// </summary>
        /// <param name="id"> id of connection in db</param>
        /// <param name="include"> whether to include other tables</param>
        /// <returns> get DTO for client connection, null if not found</returns>
        Task<ClientConnectionGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Updates connection
        /// </summary>
        /// <param name="entityDto"> client connection update DTO</param>
        Task UpdateAsync(ClientConnectionUpdateDTO entityDto);

        /// <summary>
        /// Deletes connection
        /// </summary>
        /// <param name="id"> id of connection in db</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets all client connections
        /// </summary>
        /// <param name="clientId"> optional client id to filter on</param>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns> query result with client conecction get DTOs</returns>
        Task<QueryResultDTO<ClientConnectionGetDTO>> GetAllConnectionsAsync(int? clientId,
            QueryPagingDTO? queryPagingDto = null);
    }
}