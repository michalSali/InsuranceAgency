using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for insurance agents
    /// </summary>
    public class InsuranceAgentFilter
    {
        public static IQueryable<InsuranceAgent> IncludeUser(IQueryable<InsuranceAgent> queryable)
        {
            return queryable.Include(i => i.User);
        }

        public static IQueryable<InsuranceAgent> IncludeEverything(IQueryable<InsuranceAgent> queryable)
        {
            return IncludeUser(queryable.Include(i => i.Clients)
                .Include(i => i.Director));
        }
    }
}