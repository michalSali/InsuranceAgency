using AutoMapper;
using BLL.DTOs.People.InsuranceAgent;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace BLL.Services.InsuranceAgent
{
    /// <summary>
    /// Insurance agent service with CRUD operations and queries
    /// </summary>
    public class InsuranceAgentService : ServiceBase<InsuranceAgentCreateDTO, InsuranceAgentGetDTO,
        InsuranceAgentGetDTO, DAL.Models.InsuranceAgent>, IInsuranceAgentService
    {
        /// <summary>
        /// Constructs insurance agent service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with agent entity type </param>
        /// <param name="queryObject">query object that queries agent entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between agent DTOs and entities in any order </param>
        public InsuranceAgentService(IRepository<DAL.Models.InsuranceAgent> repository,
            IQueryObject<InsuranceAgentGetDTO, DAL.Models.InsuranceAgent> queryObject, IMapper mapper) : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the agent entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override InsuranceAgentGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.InsuranceAgent.Clients),
                nameof(DAL.Models.InsuranceAgent.Director), nameof(DAL.Models.InsuranceAgent.User));
            return mapper.Map<InsuranceAgentGetDTO>(entity);
        }

        public Task<QueryResultDTO<InsuranceAgentGetDTO>> GetAllInsuranceAgentsAsync(bool include = true,
            int? directorId = null, QueryPagingDTO? queryPagingDto = null)
        {
            QueryFilterDTO<DAL.Models.InsuranceAgent> filter = new InsuranceAgentFilterDTO();
            if (directorId != null)
            {
                filter = new InsuranceAgentFilterDTO(directorId.Value);
            }
            if (include)
            {
                filter.Include.Add(InsuranceAgentFilter.IncludeEverything);
            }
            else
            {
                filter.Include.Add(InsuranceAgentFilter.IncludeUser);
            }
            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery();
        }
    }
}