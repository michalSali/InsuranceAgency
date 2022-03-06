using DAL.Models;
using DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for clients
    /// </summary>
    public static class ClientFilters
    {
        #region Private

        private static IQueryable<Client> IncludeUserIfMissing(IQueryable<Client> queryable)
        {
            return queryable.Include(c => c.User);
        }

        #endregion Private

        #region Filters

        public static IQueryable<Client> FilterMen(IQueryable<Client> queryable)
        {
            queryable = IncludeUserIfMissing(queryable);
            return queryable.Where(c => c.User.Gender == Gender.Male);
        }

        public static IQueryable<Client> FilterWomen(IQueryable<Client> queryable)
        {
            queryable = IncludeUserIfMissing(queryable);
            return queryable.Where(c => c.User.Gender == Gender.Female);
        }

        #endregion Filters

        #region Includes

        public static IQueryable<Client> IncludeUser(IQueryable<Client> queryable)
        {
            return queryable.Include(client => client.User);
        }

        public static IQueryable<Client> IncludeInsuranceAgent(IQueryable<Client> queryable)
        {
            return queryable.Include(client => client.InsuranceAgent);
        }

        public static IQueryable<Client> IncludeClientConnections(IQueryable<Client> queryable)
        {
            return queryable.Include(client => client.ObjectConnections).ThenInclude(connection => connection.Subject)
                .Include(client => client.SubjectConnections).ThenInclude(connection => connection.Object);
        }

        public static IQueryable<Client> IncludeBackgroundInfo(IQueryable<Client> queryable)
        {
            return queryable.Include(client => client.BackgroundInfos);
        }

        public static IQueryable<Client> IncludeGear(IQueryable<Client> queryable)
        {
            return queryable.Include(client => client.Gears);
        }

        public static IQueryable<Client> IncludeExtendedInfo(IQueryable<Client> queryable)
        {
            return IncludeClientConnections(IncludeBackgroundInfo(IncludeGear(IncludeInsuranceAgent(IncludeUser(queryable)))));
        }

        public static IQueryable<Client> IncludeInsurances(IQueryable<Client> queryable)
        {
            return queryable.Include(client => client.ClientInsurances)
                .ThenInclude(insurance => insurance.InsuranceOffer);
        }

        public static IQueryable<Client> IncludeConflicts(IQueryable<Client> queryable)
        {
            return queryable.Include(client => client.ConflictInvolvements)
                .ThenInclude(involvement => involvement.Conflict)
                .Include(client => client.ConflictInvolvements)
                .ThenInclude(involvement => involvement.ConflictRecords);
        }

        public static IQueryable<Client> IncludeEverything(IQueryable<Client> queryable)
        {
            return IncludeExtendedInfo(IncludeInsurances(IncludeConflicts(queryable)));
        }

        #endregion Includes

        #region Sorts

        public static IOrderedQueryable<Client> SortByName(IQueryable<Client> queryable)
        {
            queryable = IncludeUserIfMissing(queryable);
            return queryable.OrderBy(c => c.User.Name);
        }

        public static IOrderedQueryable<Client> SortByNameDescending(IQueryable<Client> queryable)
        {
            queryable = IncludeUserIfMissing(queryable);
            return queryable.OrderByDescending(c => c.User.Name);
        }

        #endregion Sorts
    }
}