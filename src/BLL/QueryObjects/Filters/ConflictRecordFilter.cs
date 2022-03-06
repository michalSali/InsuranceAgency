using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for conflict records
    /// </summary>
    public static class ConflictRecordFilter
    {
        public static IQueryable<ConflictRecord> IncludeParticipantAndConflict(IQueryable<ConflictRecord> queryable)
        {
            return queryable.Include(r => r.ConflictInvolvement).ThenInclude(i => i.Client)
                .Include(r => r.ConflictInvolvement).ThenInclude(i => i.Conflict);
        }

        public static IOrderedQueryable<ConflictRecord> SortByDate(IQueryable<ConflictRecord> queryable)
        {
            return queryable.OrderBy(r => r.Date);
        }
    }
}