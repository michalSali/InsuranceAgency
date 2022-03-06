using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for client connections
    /// </summary>
    public static class ClientConnectionsFilter
    {
        public static IQueryable<ClientConnection> IncludeParticipants(IQueryable<ClientConnection> queryable)
        {
            return queryable.Include(c => c.Subject).
                Include(c => c.Object);
        }
    }
}