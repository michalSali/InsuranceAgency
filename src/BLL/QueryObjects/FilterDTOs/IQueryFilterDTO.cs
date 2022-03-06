using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// Interface for query filter DTO that is used during query execution to filter/sort/include entities
    /// </summary>
    /// <typeparam name="TEntity"> entity from DAL used in database </typeparam>
    public interface IQueryFilterDTO<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Access filter functions that are sequentially used on the query
        /// </summary>
        List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> Filter { get; set; }

        /// <summary>
        /// Access filter functions that are sequentially used on the query after includes
        /// </summary>
        List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> AfterIncludeFilter { get; set; }

        /// <summary>
        /// Access sorting functions that are sequentially used on the query
        /// </summary>
        List<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> Sort { get; set; }

        /// <summary>
        /// Access include functions which are sequentially used on the query
        /// </summary>
        List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> Include { get; set; }
    }
}