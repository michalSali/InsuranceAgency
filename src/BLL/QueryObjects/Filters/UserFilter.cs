using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for users
    /// </summary>
    public static class UserFilter
    {
        #region Filters

        public static IQueryable<User> IncludeRoles(IQueryable<User> queryable)
        {
            return queryable.Include(u => u.Administrator)
                .Include(u => u.Client)
                .Include(u => u.Director)
                .Include(u => u.InsuranceAgent);
        }

        #endregion Filters
    }
}