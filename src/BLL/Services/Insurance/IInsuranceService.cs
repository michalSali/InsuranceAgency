using BLL.DTOs.Objects.Insurance;
using BLL.QueryObjects;
using System.Threading.Tasks;

namespace BLL.Services.Insurance
{
    /// <summary>
    /// Interface for insurance service
    /// </summary>
    public interface IInsuranceService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        Task<int> CreateAsync(InsuranceCreateDTO entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<InsuranceGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        Task UpdateAsync(InsuranceUpdateDTO entityDto);

        /// <summary>
        /// Deletes insurance by id
        /// </summary>
        /// <param name="id"> id of conflict in db</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets all insurance agents
        /// </summary>
        /// <param name="clientId"> optional client id to filter on</param>
        /// <param name="active"> flag whether only active insurances should be taken </param>
        /// <param name="sort"> flag whether to sort by date </param>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns>query result with insurance get DTOs</returns>
        Task<QueryResultDTO<InsuranceGetDTO>> GetAllInsurancesAsync(int? clientId,
            bool active, bool sort, QueryPagingDTO? queryPagingDto = null);

        /// <summary>
        /// Gets all insurance agents with includes
        /// </summary>
        /// <param name="clientId"> optional client id to filter on</param>
        /// <param name="active"> flag whether only active insurances should be taken </param>
        /// <param name="sort"> flag whether to sort by date </param>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns>query result with insurance get DTOs</returns>
        Task<QueryResultDTO<InsuranceGetDTO>> GetAllInsurancesWithIncludesAsync(int? clientId,
            bool active, bool sort, QueryPagingDTO? queryPagingDto = null);
    }
}