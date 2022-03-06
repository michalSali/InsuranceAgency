using AutoMapper;
using BLL.DTOs.People.Director;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace BLL.Services.Director
{
    /// <summary>
    /// Director service with CRUD operations and queries
    /// </summary>
    public class DirectorService : ServiceBase<DirectorCreateDTO, DirectorUpdateDTO,
        DirectorGetDTO, DAL.Models.Director>, IDirectorService
    {
        /// <summary>
        /// Constructs director service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with director entity type </param>
        /// <param name="queryObject">query object that queries director entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between director DTOs and entities in any order </param>
        public DirectorService(IRepository<DAL.Models.Director> repository,
            IQueryObject<DirectorGetDTO, DAL.Models.Director> queryObject,
            IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the director entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override DirectorGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.Director.User),
                nameof(DAL.Models.Director.Conflicts),
                nameof(DAL.Models.Director.InsuranceAgents),
                nameof(DAL.Models.Director.InsuranceOffers));
            return mapper.Map<DirectorGetDTO>(entity);
        }

        public Task<QueryResultDTO<DirectorGetDTO>> GetAllDirectorsAsync(bool include = true,
            QueryPagingDTO? queryPagingDto = null)
        {
            var filter = new QueryFilterDTO<DAL.Models.Director>();
            if (include)
            {
                filter.Include.Add(DirectorFilter.IncludeEverything);
            }
            else
            {
                filter.Include.Add(DirectorFilter.IncludeUser);
            }
            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }
    }
}