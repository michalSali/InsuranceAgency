using AutoMapper;
using BLL.QueryObjects.FilterDTOs;
using DAL.Infrastructure.UnitOfWork;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.QueryObjects
{
    /// <summary>
    /// Generic Query object
    /// </summary>
    /// <typeparam name="TEntityDTO"> Entity to return</typeparam>
    /// <typeparam name="TEntity"> Entity in the query </typeparam>
    public class QueryObject<TEntityDTO, TEntity> : IQueryObject<TEntityDTO, TEntity>
        where TEntityDTO : class
        where TEntity : class, IEntity
    {
        private readonly IMapper mapper;
        private List<IQueryFilterDTO<TEntity>> queryFilters = new List<IQueryFilterDTO<TEntity>>();
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        // applies all the stored filters
        private IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> queryable)
        {
            if (queryable == null)
            {
                return null;
            }
            foreach (var queryFilterDTO in queryFilters)
            {
                foreach (var filter in queryFilterDTO.Filter)
                {
                    queryable = filter(queryable);
                }

                foreach (var include in queryFilterDTO.Include)
                {
                    queryable = include(queryable);
                }

                foreach (var filter in queryFilterDTO.AfterIncludeFilter)
                {
                    queryable = filter(queryable);
                }

                foreach (var sort in queryFilterDTO.Sort)
                {
                    queryable = sort(queryable);
                }
            }
            queryFilters.Clear();
            return queryable;
        }

        public async Task<QueryResultDTO<TEntityDTO>> ExecuteQuery(QueryPagingDTO? queryPagingDto = null)
        {
            var queryable = ((UnitOfWork) unitOfWorkProvider.GetUnitOfWorkInstance()).Context.Set<TEntity>().AsQueryable();
            queryable = ApplyFilter(queryable);
            List<TEntity> res;
            if (queryPagingDto != null)
            {
                int desiredPage = queryPagingDto.Value.DesiredPage;
                int pageSize = queryPagingDto.Value.PageSize;
                res = await queryable.Skip((desiredPage - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                res = queryable.ToList();
            }
            return new QueryResultDTO<TEntityDTO>(mapper.Map<List<TEntityDTO>>(res), queryPagingDto);
        }

        public void AddFilter(IQueryFilterDTO<TEntity> queryFilterDTO)
        {
            queryFilters.Add(queryFilterDTO);
        }

        /// <summary>
        /// Constructs the query object from UOWProvider and mapper
        /// </summary>
        /// <param name="unitOfWorkProvider"> UOWProvider which supplies UOW with Context getter </param>
        /// <param name="mapper"> mapper that can map TEntity to EntityDTO</param>
        public QueryObject(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.mapper = mapper;
        }
    }
}