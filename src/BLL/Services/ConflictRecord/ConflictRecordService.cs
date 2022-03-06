using AutoMapper;
using BLL.DTOs.Objects.ConflictRecord;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.ConflictRecord
{
    /// <summary>
    /// Director service with CRUD operations and queries
    /// </summary>
    public class ConflictRecordService : ServiceBase<ConflictRecordCreateDTO, ConflictRecordUpdateDTO,
        ConflictRecordGetDTO, DAL.Models.ConflictRecord>, IConflictRecordService
    {
        /// <summary>
        /// Constructs conflict record service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with conflict record entity type </param>
        /// <param name="queryObject">query object that queries entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between conflict record DTOs and entities in any order </param>
        public ConflictRecordService(IRepository<DAL.Models.ConflictRecord> repository,
            IQueryObject<ConflictRecordGetDTO,
                DAL.Models.ConflictRecord> queryObject,
            IMapper mapper) : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the conflict record entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override ConflictRecordGetDTO GetWithIncludes(int id)
        {
            var filter = new QueryFilterDTO<DAL.Models.ConflictRecord>();
            filter.Include.Add(ConflictRecordFilter.IncludeParticipantAndConflict);
            filter.Filter.Add(queyable => queyable.Where(record => record.Id == id));
            queryObject.AddFilter(filter);
            var result = queryObject.ExecuteQuery(new QueryPagingDTO(1,1));
            return result.Result.Dtos.First();
        }

        public Task<QueryResultDTO<ConflictRecordGetDTO>> GetAllRecordsWithParticipantIdSorted(int id,
            QueryPagingDTO? queryPagingDto = null)
        {
            var filter = new QueryFilterDTO<DAL.Models.ConflictRecord>();
            filter.Include.Add(ConflictRecordFilter.IncludeParticipantAndConflict);
            filter.Sort.Add(ConflictRecordFilter.SortByDate);
            filter.AfterIncludeFilter.Add(
                queryable => queryable.Where(r => r.ConflictInvolvement.ClientId == id));
            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }

        public Task<QueryResultDTO<ConflictRecordGetDTO>> GetAllRecordsWithConflictIdSorted(int id,
            QueryPagingDTO? queryPagingDto = null)
        {
            var filter = new QueryFilterDTO<DAL.Models.ConflictRecord>();
            filter.Include.Add(ConflictRecordFilter.IncludeParticipantAndConflict);
            filter.Sort.Add(ConflictRecordFilter.SortByDate);
            filter.AfterIncludeFilter.Add(
                queryable => queryable.Where(r => r.ConflictInvolvement.ConflictId == id));
            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }
    }
}