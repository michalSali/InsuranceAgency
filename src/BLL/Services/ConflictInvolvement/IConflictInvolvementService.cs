using BLL.DTOs.Objects.ConflictInvolvement;
using System.Threading.Tasks;
using BLL.DTOs.Objects.ConflictRecord;
using BLL.QueryObjects;
using BLL.QueryObjects.Filters;

namespace BLL.Services.ConflictInvolvement
{
    /// <summary>
    /// Defines interface for conflict involvement service
    /// </summary>
    public interface IConflictInvolvementService
    {
        /// <summary>
        /// Creates conflict involvement entity
        /// </summary>
        /// <param name="entityDto"> DTO of entity to create </param>
        /// <returns> id of entity, -1 if not created </returns>
        Task<int> CreateAsync(ConflictInvolvementCreateDTO entityDto);

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        /// <param name="id"> int of entity in db </param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id"> id of entity in db </param>
        /// <param name="include"> whether to include </param>
        /// <returns> DTO of entity to get </returns>
        Task<ConflictInvolvementGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Gets conflict involvement based on client id and conflict id 
        /// </summary>
        /// <param name="clientId">id of client</param>
        /// <param name="conflictId">id of conflict</param>
        /// <returns> null if not found otherwise get dto for entity </returns>
        Task<ConflictInvolvementGetDTO> GetAsync(int clientId, int conflictId);

        /// <summary>
        /// Gets all conflict involvements for given client
        /// </summary>
        /// <param name="clientId"> id of client </param>
        /// <param name="queryPagingDto"> optional paging to use </param>
        /// <returns> query result with get dto of entity </returns>
        Task<QueryResultDTO<ConflictInvolvementGetDTO>> GetAllInvolvementsByClientAsync(int clientId,
            QueryPagingDTO? queryPagingDto = null);

        /// <summary>
        /// Gets all conflict involvements
        /// </summary>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns> query result with get dto of entity </returns>
        Task<QueryResultDTO<ConflictInvolvementGetDTO>> GetAllConflictInvolvementsAsync(
            QueryPagingDTO? queryPagingDto = null);
    }
}