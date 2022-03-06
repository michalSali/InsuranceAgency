using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// Generic filter DTO used to filter queries
    /// </summary>
    /// <typeparam name="TEntity"> database entity that is fitered </typeparam>
    public class QueryFilterDTO<TEntity> : IQueryFilterDTO<TEntity> where TEntity : class, IEntity
    {
        
        public List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> Filter { get; set; }
            = new List<Func<IQueryable<TEntity>, IQueryable<TEntity>>>();

        
        public List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> AfterIncludeFilter { get; set; }
            = new List<Func<IQueryable<TEntity>, IQueryable<TEntity>>>();

        
        public List<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> Sort { get; set; }
            = new List<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>>();

        
        public List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> Include { get; set; }
            = new List<Func<IQueryable<TEntity>, IQueryable<TEntity>>>();

        /// <summary>
        /// Constructs empty filter DTO
        /// </summary>
        public QueryFilterDTO()
        {
        }

        /// <summary>
        /// Constructs query filter DTO
        /// </summary>
        /// <param name="filter"> filtering function </param>
        /// <param name="afterIncludeFilter"> filtering function to be used after include </param>
        /// <param name="sort"> sorting function </param>
        /// <param name="include"> include function</param>
        public QueryFilterDTO(Func<IQueryable<TEntity>, IQueryable<TEntity>> filter,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> afterIncludeFilter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include)
        {
            Filter.Add(filter);
            AfterIncludeFilter.Add(afterIncludeFilter);
            Sort.Add(sort);
            Include.Add(include);
        }

        /// <summary>
        /// Constructs query filter DTO
        /// </summary>
        /// <param name="filter"> filtering functions </param>
        /// <param name="afterIncludeFilter"> filtering functions to be used after include </param>
        /// <param name="sort"> sorting functions </param>
        /// <param name="include"> include functions</param>
        public QueryFilterDTO(List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> filter,
            List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> afterIncludeFilter,
            List<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> sort,
            List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> include)
        {
            Filter = filter;
            AfterIncludeFilter = afterIncludeFilter;
            Sort = sort;
            Include = include;
        }
    }
}