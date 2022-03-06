using BLL.DTOs.Objects.InsuranceOffer;
using BLL.QueryObjects;
using System.Threading.Tasks;

namespace BLL.Services.InsuranceOffer
{
    /// <summary>
    /// Interface for insurance offer service
    /// </summary>
    public interface IInsuranceOfferService
    {
        /// <summary>
        /// Creates insurance offer entity
        /// </summary>
        /// <param name="entityDto"> create DTO of insurance offer </param>
        /// <returns> id of new insurance offer, -1 if failed</returns>
        Task<int> CreateAsync(InsuranceOfferCreateDTO entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns>get DTO of insurance offer</returns>
        Task<InsuranceOfferGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Updates insurance offer entity
        /// </summary>
        /// <param name="entityDto"> insurance offer update DTO</param>
        Task UpdateAsync(InsuranceOfferUpdateDTO entityDto);

        /// <summary>
        /// Get all insurance offers with optional paging
        /// </summary>
        /// <param name="directorId"> optional director id </param>
        /// <param name="active"> optional flag whether to filter active </param>
        /// <param name="sort"> optional flag whether to sort by date </param>
        /// <param name="queryPagingDto"> optional paging</param>
        /// <returns>query result with insurance offer get DTOs</returns>
        Task<QueryResultDTO<InsuranceOfferGetDTO>> GetAllOffersAsync(
            int? directorId, bool active, bool sort = true, QueryPagingDTO? queryPagingDto = null);

        /// <summary>
        /// Get all insurance offers with optional paging and includes
        /// </summary>
        /// <param name="directorId"> optional director id </param>
        /// <param name="active"> optional flag whether to filter active </param>
        /// <param name="sort"> optional flag whether to sort by date </param>
        /// <param name="queryPagingDto"> optional paging</param>
        /// <returns>query result with insurance offer get DTOs</returns>
        Task<QueryResultDTO<InsuranceOfferGetDTO>> GetAllOffersWithIncludesAsync(
            int? directorId, bool active, bool sort = true, QueryPagingDTO? queryPagingDto = null);
    }
}