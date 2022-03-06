using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for directors
    /// </summary>
    public static class DirectorFilter
    {
        public static IQueryable<Director> IncludeUser(IQueryable<Director> queryable)
        {
            return queryable.Include(d => d.User);
        }

        public static IQueryable<Director> IncludeEverything(IQueryable<Director> queryable)
        {
            return IncludeUser(queryable.Include(d => d.Conflicts)
                .Include(d => d.InsuranceAgents)
                .Include(d => d.InsuranceOffers));
        }
    }
}