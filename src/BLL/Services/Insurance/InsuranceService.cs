using AutoMapper;
using BLL.DTOs.Objects.Insurance;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using DAL.Models;
using System.Threading.Tasks;

namespace BLL.Services.Insurance
{
    /// <summary>
    /// Insurances service with CRUD operations and queries
    /// </summary>
    public class InsuranceService : ServiceBase<InsuranceCreateDTO, InsuranceUpdateDTO,
        InsuranceGetDTO, DAL.Models.ClientInsurance>, IInsuranceService
    {
        /// <summary>
        /// Constructs insurance service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with given entity type </param>
        /// <param name="queryObject">query object that queries entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between DTOs and entities in any order </param>
        public InsuranceService(IRepository<ClientInsurance> repository,
            IQueryObject<InsuranceGetDTO, ClientInsurance> queryObject,
            IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the insurance entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override InsuranceGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.ClientInsurance.InsuranceOffer),
                nameof(DAL.Models.ClientInsurance.Client));
            return mapper.Map<InsuranceGetDTO>(entity);
        }

        public Task<QueryResultDTO<InsuranceGetDTO>> GetAllInsurancesAsync(int? clientId,
            bool active, bool sort, QueryPagingDTO? queryPagingDto = null)
        {
            var filter = (clientId == null)
                ? new InsuranceFilterDTO(active, sort)
                : new InsuranceFilterDTO(clientId.Value, active, sort);

            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }

        public Task<QueryResultDTO<InsuranceGetDTO>> GetAllInsurancesWithIncludesAsync(int? clientId,
            bool active, bool sort, QueryPagingDTO? queryPagingDto = null)
        {
            var filter = (clientId == null)
                ? new InsuranceFilterDTO(active, sort)
                : new InsuranceFilterDTO(clientId.Value, active, sort);

            filter.Include.Add(InsuranceFilter.IncludeEverything);

            queryObject.AddFilter(filter);            
            return queryObject.ExecuteQuery(queryPagingDto);
        }
    }
}