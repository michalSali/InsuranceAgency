using BLL.DTOs.Objects.ConflictRecord;
using BLL.QueryObjects;
using System.Threading.Tasks;
using BLL.QueryObjects.Filters;

namespace BLL.Services.ConflictRecord
{
    /// <summary>
    /// Interface for conflict record service
    /// </summary>
    public interface IConflictRecordService
    {
        /// <summary>
        /// Creates new conflict record
        /// </summary>
        /// <param name="entityDto"> create DTO of conflict record</param>
        /// <returns> id of new record, -1 if failed</returns>
        Task<int> CreateAsync(ConflictRecordCreateDTO entityDto);

        /// <summary>
        /// Gets conflict record by id
        /// </summary>
        /// <param name="id"> id in db</param>
        /// <param name="include">whether to include other tables</param>
        /// <returns> null if not found otherwise record get DTO</returns>
        Task<ConflictRecordGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Updates conflict record
        /// </summary>
        /// <param name="entityDto"> update DTO of conflict record</param>
        Task UpdateAsync(ConflictRecordUpdateDTO entityDto);

        /// <summary>
        /// Deletes record by id 
        /// </summary>
        /// <param name="id">id of conflict record in db</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get all records with participant id sorted
        /// </summary>
        /// <param name="id"> id of participant (client) to filter on </param>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns>query result with conflict records get DTOs</returns>
        Task<QueryResultDTO<ConflictRecordGetDTO>> GetAllRecordsWithParticipantIdSorted(int id,
            QueryPagingDTO? queryPagingDto = null);

        /// <summary>
        /// Get all records with given conflict id sorted
        /// </summary>
        /// <param name="id"> conflict id to filter on </param>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns>query result with record get dto</returns>
        Task<QueryResultDTO<ConflictRecordGetDTO>> GetAllRecordsWithConflictIdSorted(int id,
            QueryPagingDTO? queryPagingDto = null);
    }
}