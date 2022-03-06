using AutoMapper;
using BLL.DTOs.Objects.Conflict;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.Conflict
{
    /// <summary>
    /// Conflict service with CRUD operations and queries
    /// </summary>
    public class ConflictService : ServiceBase<ConflictCreateDTO, ConflictUpdateDTO, ConflictGetDTO, DAL.Models.Conflict>, IConflictService
    {
        /// <summary>
        /// Constructs conflict service base with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with conflict entity type </param>
        /// <param name="queryObject">query object that queries entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between conflict DTOs and entities in any order </param>
        public ConflictService(IRepository<DAL.Models.Conflict> repository, IQueryObject<ConflictGetDTO,
            DAL.Models.Conflict> queryObject, IMapper mapper) : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the conflict entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override ConflictGetDTO GetWithIncludes(int id)
        {
            var filter = new QueryFilterDTO<DAL.Models.Conflict>();
            filter.Include.Add(ConflictFilter.IncludeParticipantsAndRecords);
            filter.Filter.Add(queyable => queyable.Where(record => record.Id == id));
            queryObject.AddFilter(filter);
            var result = queryObject.ExecuteQuery(new QueryPagingDTO(1, 1));
            return result.Result.Dtos.First();
        }

        public Task<QueryResultDTO<ConflictGetDTO>> GetAllConflictsAsync(
            int? directorId, bool active, bool sort, QueryPagingDTO? queryPagingDto = null)
        {
            var filter = (directorId == null)
                ? new ConflictFilterDTO(active, sort)
                : new ConflictFilterDTO(directorId.Value, active, sort);

            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }
    }
}