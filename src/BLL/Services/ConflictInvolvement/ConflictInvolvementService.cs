using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs.Objects.ConflictInvolvement;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;

namespace BLL.Services.ConflictInvolvement
{
    /// <summary>
    /// Conflict involvement service with CRUD operations and queries.
    /// </summary>
    public class ConflictInvolvementService
        : ServiceBase<ConflictInvolvementCreateDTO, ConflictInvolvementGetDTO, ConflictInvolvementGetDTO,
            DAL.Models.ConflictInvolvement>, IConflictInvolvementService
    {
        /// <summary>
        /// Constructs conflict involvement service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with conflict involvement entity type </param>
        /// <param name="queryObject">query object that queries entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between conflict involvement DTOs and entities in any order </param>
        public ConflictInvolvementService(IRepository<DAL.Models.ConflictInvolvement> repository,
            IQueryObject<ConflictInvolvementGetDTO, DAL.Models.ConflictInvolvement> queryObject,
            IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override ConflictInvolvementGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id,
                nameof(DAL.Models.ConflictInvolvement.Client),
                nameof(DAL.Models.ConflictInvolvement.Conflict),
                nameof(DAL.Models.ConflictInvolvement.ConflictRecords));
            return mapper.Map<ConflictInvolvementGetDTO>(entity);
        }

        public async Task<ConflictInvolvementGetDTO> GetAsync(int clientId, int conflictId)
        {
            var filter = new ConflictInvolvementFilterDTO(clientId, conflictId);
            queryObject.AddFilter(filter);
            return (await queryObject.ExecuteQuery(new QueryPagingDTO(1,1))).Dtos.FirstOrDefault();
        }

        public Task<QueryResultDTO<ConflictInvolvementGetDTO>> GetAllInvolvementsByClientAsync(int clientId,
            QueryPagingDTO? queryPagingDto = null)
        {
            var filter = new ConflictInvolvementFilterDTO(clientId);
            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }

        public Task<QueryResultDTO<ConflictInvolvementGetDTO>> GetAllConflictInvolvementsAsync(
            QueryPagingDTO? queryPagingDto = null)
        {
            return queryObject.ExecuteQuery(queryPagingDto);
        }
    }
}