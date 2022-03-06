using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.People.InsuranceAgent;

namespace BLL.Facades.InsuranceAgent
{
    public interface IInsuranceAgentFacade
    {
        Task<InsuranceAgentGetDTO> GetAsync(int id);

        Task<InsuranceAgentGetDTO> GetWithIncludesAsync(int id);

        Task<IEnumerable<InsuranceAgentGetDTO>> GetAllAsync(int? directorId);

        Task<IEnumerable<InsuranceAgentGetDTO>> GetAllWithIncludesAsync(int directorId);        
    }
}