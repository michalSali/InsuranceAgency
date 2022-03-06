using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for conflicts
    /// </summary>
    public class ConflictFilter
    {
        # region Filters

        public static IQueryable<Conflict> FilterActive(IQueryable<Conflict> queryable)
        {
            return queryable.Where(conflict => conflict.End == null);
        }

        public static IQueryable<Conflict> FilterInActive(IQueryable<Conflict> queryable)
        {
            return queryable.Where(conflict => conflict.End != null);
        }

        #endregion

        #region Includes

        public static IQueryable<Conflict> IncludeRecords(IQueryable<Conflict> queryable)
        {
            return queryable.Include(conflict => conflict.ConflictInvolvements)
                .ThenInclude(involvement => involvement.ConflictRecords);
        }

        #endregion

        public static IQueryable<Conflict> IncludeParticipantsAndRecords(IQueryable<Conflict> queryable)
        {
            return queryable.Include(c => c.ConflictInvolvements).ThenInclude(i => i.Client)
                .Include(c => c.ConflictInvolvements).ThenInclude(i => i.ConflictRecords);
        }

        #region Sorts

        public static IQueryable<Conflict> SortByStartDate(IQueryable<Conflict> queryable)
        {
            return queryable.OrderBy(conflict => conflict.Beginning);
        }

        #endregion

        public static IOrderedQueryable<Conflict> SortByDate(IQueryable<Conflict> queryable)
        {
            return queryable.OrderBy(c => c.Beginning);
        }
    }
}