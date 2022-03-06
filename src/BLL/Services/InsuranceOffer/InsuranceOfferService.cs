using AutoMapper;
using BLL.DTOs.Objects.InsuranceOffer;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace BLL.Services.InsuranceOffer
{
    /// <summary>
    /// Insurance offer service with CRUD operations and queries
    /// </summary>
    public class InsuranceOfferService : ServiceBase<InsuranceOfferCreateDTO, InsuranceOfferUpdateDTO,
        InsuranceOfferGetDTO, DAL.Models.InsuranceOffer>, IInsuranceOfferService
    {
        /// <summary>
        /// Constructs insurance offer service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with given entity type </param>
        /// <param name="queryObject">query object that queries entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between DTOs and entities in any order </param>
        public InsuranceOfferService(IRepository<DAL.Models.InsuranceOffer> repository,
            IQueryObject<InsuranceOfferGetDTO, DAL.Models.InsuranceOffer> queryObject,
            IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the offer entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations for offers </returns>
        protected override InsuranceOfferGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.InsuranceOffer.Director),
                nameof(DAL.Models.InsuranceOffer.ClientInsurances));
            return mapper.Map<InsuranceOfferGetDTO>(entity);
        }

        public Task<QueryResultDTO<InsuranceOfferGetDTO>> GetAllOffersAsync( 
            int? directorId, bool active, bool sort=true, QueryPagingDTO? queryPagingDto = null)
        {
            var filter = (directorId == null)
                ? new InsuranceOfferFilterDTO(active, sort)
                : new InsuranceOfferFilterDTO(directorId.Value, active, sort);

            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }

        public Task<QueryResultDTO<InsuranceOfferGetDTO>> GetAllOffersWithIncludesAsync(int? directorId,
            bool active, bool sort, QueryPagingDTO? queryPagingDto = null)
        {
            var filter = (directorId == null)
                ? new InsuranceOfferFilterDTO(active, sort)
                : new InsuranceOfferFilterDTO(directorId.Value, active, sort);

            filter.Include.Add(InsuranceOffersFilter.IncludeEverything);

            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }
    }
}