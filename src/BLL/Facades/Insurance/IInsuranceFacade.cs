using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.Objects.Insurance;
using BLL.DTOs.Objects.InsuranceOffer;
using BLL.QueryObjects;

namespace BLL.Facades.Insurance
{
    public interface IInsuranceFacade
    {
        Task<bool> DeleteInsuranceAsync(int id);

        Task<int> CreateInsuranceOfferAsync(InsuranceOfferCreateDTO entityDto);
        
        Task<int> CreateInsuranceAsync(InsuranceCreateDTO entityDto);

        Task<InsuranceOfferGetDTO> GetInsuranceOfferAsync(int id, bool include=true);
        
        Task<InsuranceGetDTO> GetInsuranceAsync(int id, bool include=true);

        Task<bool> UpdateInsuranceAsync(InsuranceUpdateDTO entityDto);

        Task<bool> UpdateInsuranceOfferAsync(InsuranceOfferUpdateDTO entityDto);

        Task<IEnumerable<InsuranceOfferGetDTO>> GetAllInsuranceOffersAsync(
            int? directorId = null, bool active = true, bool sorted = true, QueryPagingDTO? queryPagingDto = null);

        Task<IEnumerable<InsuranceOfferGetDTO>> GetAllInsuranceOffersWithIncludesAsync(
            int? directorId = null, bool active = true, bool sorted = true, QueryPagingDTO? queryPagingDto = null);

        Task<IEnumerable<InsuranceGetDTO>> GetAllInsurancesAsync(
            int? clientId = null, bool active = true, bool sorted = true, QueryPagingDTO? queryPagingDto = null);

        Task<IEnumerable<InsuranceGetDTO>> GetAllInsurancesWithIncludesAsync(
            int? clientId = null, bool active = true, bool sorted = true, QueryPagingDTO? queryPagingDto = null);
    }
}