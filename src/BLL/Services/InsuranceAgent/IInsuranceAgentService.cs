using BLL.DTOs.People.InsuranceAgent;
using BLL.QueryObjects;
using System.Threading.Tasks;

namespace BLL.Services.InsuranceAgent
{
    /// <summary>
    /// Interface for insurance agent service
    /// </summary>
    public interface IInsuranceAgentService
    {
        /// <summary>
        /// Creates new insurance agent
        /// </summary>
        /// <param name="entityDto"> create DTO</param>
        /// <returns> id of new agent, -1 if failed</returns>
        Task<int> CreateAsync(InsuranceAgentCreateDTO entityDto);

        /// <summary>
        /// Gets insurance agent by id
        /// </summary>
        /// <param name="id"> id of agent in db</param>
        /// <param name="include"> whether to include</param>
        /// <returns> get DTO, null of not found</returns>
        Task<InsuranceAgentGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Deletes insurance agent by id
        /// </summary>
        /// <param name="id"> id of agent</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets all insurance agents
        /// </summary>
        /// <param name="include"> whether to include other tables</param>
        /// <param name="directorId"> optional director id to filter on </param>
        /// <param name="queryPagingDto">optional paging</param>
        /// <returns>query result with agent DTOs</returns>
        Task<QueryResultDTO<InsuranceAgentGetDTO>> GetAllInsuranceAgentsAsync(bool include = true, int? directorId=null,
            QueryPagingDTO? queryPagingDto = null);
    }
}