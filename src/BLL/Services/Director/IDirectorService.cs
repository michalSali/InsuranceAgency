using BLL.DTOs.People.Director;
using BLL.QueryObjects;
using System.Threading.Tasks;
using BLL.QueryObjects.Filters;

namespace BLL.Services.Director
{
    /// <summary>
    /// Interface for director service
    /// </summary>
    public interface IDirectorService
    {
        /// <summary>
        /// Creates new director
        /// </summary>
        /// <param name="entityDto"> create DTO of director </param>
        /// <returns> id of new director, -1 if failed</returns>
        Task<int> CreateAsync(DirectorCreateDTO entityDto);

        /// <summary>
        /// Updates director
        /// </summary>
        /// <param name="entityDto"> update DTO of director </param>
        Task UpdateAsync(DirectorUpdateDTO entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<DirectorGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Deletes director by id
        /// </summary>
        /// <param name="id"> id of director in db </param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets all directors
        /// </summary>
        /// <param name="include"> whether to include </param>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns> query result with director get DTOs</returns>
        Task<QueryResultDTO<DirectorGetDTO>> GetAllDirectorsAsync(bool include = true,
            QueryPagingDTO? queryPagingDto = null);
    }
}