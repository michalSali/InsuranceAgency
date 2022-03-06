using System.Linq;
using DAL.Models;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// DTO used to filter insurance agents
    /// </summary>
    public class InsuranceAgentFilterDTO : QueryFilterDTO<InsuranceAgent>
    {
        /// <summary>
        /// Constructs DTO that can be used to filter based on director id
        /// </summary>
        /// <param name="directorId"> id to filter on </param>
        public InsuranceAgentFilterDTO(int directorId)
        {
            Filter.Add(queryable => queryable.Where(agent => agent.DirectorId == directorId));
        }
        
        /// <summary>
        /// Constructs empty filter DTO
        /// </summary>
        public InsuranceAgentFilterDTO() {}
    }
}