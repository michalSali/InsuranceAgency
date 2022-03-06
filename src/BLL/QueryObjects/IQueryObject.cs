using BLL.QueryObjects.FilterDTOs;
using DAL.Models;
using System.Threading.Tasks;

namespace BLL.QueryObjects
{
    /// <summary>
    /// Interface for generic query object
    /// </summary>
    /// <typeparam name="TEntityDTO"> Entity DTO to return </typeparam>
    /// <typeparam name="TEntity"> Entity that is in the query </typeparam>
    public interface IQueryObject<TEntityDTO, TEntity>
        where TEntityDTO : class
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Executes the query with optional paging
        /// </summary>
        /// <param name="queryPagingDto"> if null then dont use paging, otherwise use this param </param>
        /// <returns> query result </returns>
        Task<QueryResultDTO<TEntityDTO>> ExecuteQuery(QueryPagingDTO? queryPagingDto = null);

        /// <summary>
        /// Adds filter to be sequentially applied before execution of query
        /// </summary>
        /// <param name="queryFilterDTO"> Filter DTO that contains functions to apply </param>
        public void AddFilter(IQueryFilterDTO<TEntity> queryFilterDTO);
    }
}