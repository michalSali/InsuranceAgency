using AutoMapper;
using BLL.DTOs.People.Client;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.Client
{
    /// <summary>
    /// Client service with CRUD operations and query operations
    /// </summary>
    public class ClientService : ServiceBase<ClientCreateDTO,
        ClientUpdateDTO, ClientGetDTO, DAL.Models.Client>, IClientService
    {
        /// <summary>
        /// Constructs client service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with client entity type </param>
        /// <param name="queryObject">query object that queries client entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between client DTOs and entities in any order </param>
        public ClientService(IRepository<DAL.Models.Client> repository,
            IQueryObject<ClientGetDTO, DAL.Models.Client> queryObject,
            IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the client entity by id with included user
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override ClientGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.Client.User));
            return mapper.Map<ClientGetDTO>(entity);
        }

        public async Task<ClientGetDTO> GetAsync(int id)
        {
            // use base getAsync with include set as True to include just user info
            // we dont have to use query here so use just repository via base call
            return await base.GetAsync(id, true);
        }

        private async Task<ClientGetDTO> GetByIdWithIncludeFunction(int id, Func<IQueryable<DAL.Models.Client>,
            IQueryable<DAL.Models.Client>> includeFunc)
        {
            var filter = new ClientFilterByIdDTO(id);
            filter.Include.Add(includeFunc);
            queryObject.AddFilter(filter);
            var result = await queryObject.ExecuteQuery();
            return result.Dtos.FirstOrDefault();
        }

        public async Task<ClientGetDTO> GetWithExtendedInfoAsync(int id)
        {
            return await GetByIdWithIncludeFunction(id, ClientFilters.IncludeExtendedInfo);
        }

        public async Task<ClientGetDTO> GetWithAllInfoAsync(int id)
        {
            return await GetByIdWithIncludeFunction(id, ClientFilters.IncludeEverything);
        }

        public async Task<ClientGetAggregatedDTO> GetWithAllInfoAggregatedAsync(int id)
        {
            var resultNotAggregated = await GetWithAllInfoAsync(id);
            if (resultNotAggregated == null)
            {
                return null;
            }
            return mapper.Map<ClientGetAggregatedDTO>(resultNotAggregated);
        }

        private Task<QueryResultDTO<ClientGetDTO>> GetByInsuranceAgentIdWithIncludeFunction(int? insuranceAgentId,
            QueryPagingDTO? queryPagingDto,
            Func<IQueryable<DAL.Models.Client>, IQueryable<DAL.Models.Client>> includeFunc)
        {
            var filter = new ClientFilterByInsuranceAgentIdDTO(insuranceAgentId);
            filter.Include.Add(includeFunc);
            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }

        public async Task<QueryResultDTO<ClientGetDTO>> GetAllAsync(int? insuranceAgentId = null,
            QueryPagingDTO? queryPagingDto = null)
        {
            return await GetByInsuranceAgentIdWithIncludeFunction(insuranceAgentId, queryPagingDto,
                ClientFilters.IncludeUser);
        }

        public async Task<QueryResultDTO<ClientGetDTO>> GetAllWithExtendedInfoAsync(int? insuranceAgentId = null,
            QueryPagingDTO? queryPagingDto = null)
        {
            return await GetByInsuranceAgentIdWithIncludeFunction(insuranceAgentId, queryPagingDto,
                ClientFilters.IncludeExtendedInfo);
        }

        public async Task<QueryResultDTO<ClientGetDTO>> GetAllWithAllInfoAsync(int? insuranceAgentId = null,
            QueryPagingDTO? queryPagingDto = null)
        {
            return await GetByInsuranceAgentIdWithIncludeFunction(insuranceAgentId, queryPagingDto,
                ClientFilters.IncludeEverything);
        }
        
        public Task<QueryResultDTO<ClientGetDTO>> GetAllWithAllInfoByDirectorAsync(int directorId,
            QueryPagingDTO? queryPagingDto = null)
        {
            var filter = new ClientFilterByDirectorIdDTO(directorId);
            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }

        public async Task<QueryResultDTO<ClientGetAggregatedDTO>> GetAllWithAllInfoAggregatedAsync(
            int? insuranceAgentId = null, QueryPagingDTO? queryPagingDto = null)
        {
            var resultNotAggregated = await GetAllWithAllInfoAsync(insuranceAgentId);
            return new QueryResultDTO<ClientGetAggregatedDTO>(
                mapper.Map<List<ClientGetAggregatedDTO>>(resultNotAggregated.Dtos), queryPagingDto);
        }

        public async Task<QueryResultDTO<ClientGetAggregatedDTO>> GetAllWithAllInfoAggregatedByDirectorAsync(
            int directorId, QueryPagingDTO? queryPagingDto = null)
        {
            var resultNotAggregated = await GetAllWithAllInfoByDirectorAsync(directorId);
            return new QueryResultDTO<ClientGetAggregatedDTO>(
                mapper.Map<List<ClientGetAggregatedDTO>>(resultNotAggregated.Dtos), queryPagingDto);
        }
    }
}