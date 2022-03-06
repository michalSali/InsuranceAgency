using System.Linq;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// DTO used to filter client by director id
    /// </summary>
    public class ClientFilterByDirectorIdDTO : QueryFilterDTO<Client>
    {
        /// <summary>
        /// Constructs a filter that includes user, agent and then filters by director id
        /// </summary>
        /// <param name="directorId"></param>
        public ClientFilterByDirectorIdDTO(int directorId)
        {
            Include.Add(queryable => queryable.Include(c => c.User).
                Include(c => c.InsuranceAgent));
            AfterIncludeFilter.Add(queryable => queryable.Where(
                c => c.InsuranceAgent.DirectorId == directorId));
        }
    }
}