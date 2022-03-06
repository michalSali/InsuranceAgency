using BLL.DTOs.Objects.Conflict;
using BLL.QueryObjects;
using System.Threading.Tasks;

namespace BLL.Services.Conflict
{
    /// <summary>
    /// Interface for conflict service
    /// </summary>
    public interface IConflictService
    {
        /// <summary>
        /// Creates
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        Task<int> CreateAsync(ConflictCreateDTO entityDto);

        /// <summary>
        /// Gets conflict by id 
        /// </summary>
        /// <param name="id"> id of conflict in db</param>
        /// <param name="include"> whether to include </param>
        /// <returns> null if not found, otherwise get DTO</returns>
        Task<ConflictGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Updates conflict
        /// </summary>
        /// <param name="entityDto"></param>
        Task UpdateAsync(ConflictUpdateDTO entityDto);

        /// <summary>
        /// Deletes conflict by id
        /// </summary>
        /// <param name="id"> id of conflict in db</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets all conflicts
        /// </summary>
        /// <param name="directorId"> optional director id to filter on </param>
        /// <param name="active"> flag whether to filter active</param>
        /// <param name="sort"> flag whether to sort by date</param>
        /// <param name="queryPagingDto"> optional paging</param>
        /// <returns> query result with conflict get DTOs</returns>
        public Task<QueryResultDTO<ConflictGetDTO>> GetAllConflictsAsync(int? directorId, bool active, bool sort,
            QueryPagingDTO? queryPagingDto = null);
    }
}