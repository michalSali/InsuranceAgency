using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.People.InsuranceAgent;
using BLL.Facades.Common;
using BLL.Services.Director;
using BLL.Services.InsuranceAgent;
using DAL.Infrastructure.UnitOfWork;

namespace BLL.Facades.InsuranceAgent
{
    public class InsuranceAgentFacade : FacadeBase, IInsuranceAgentFacade
    {
        private readonly IDirectorService directorService;
        private readonly IInsuranceAgentService insuranceAgentService;
        
        public InsuranceAgentFacade(IUnitOfWorkProvider unitOfWorkProvider, IDirectorService directorService,
            IInsuranceAgentService insuranceAgentService) : base(unitOfWorkProvider)
        {
            this.directorService = directorService;
            this.insuranceAgentService = insuranceAgentService;
        }

        public async Task<InsuranceAgentGetDTO> GetAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await insuranceAgentService.GetAsync(id, false);
            }
        }

        public async Task<InsuranceAgentGetDTO> GetWithIncludesAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await insuranceAgentService.GetAsync(id, true);
            }
        }

        public async Task<IEnumerable<InsuranceAgentGetDTO>> GetAllAsync(int? directorId)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (directorId == null)
                    ? (await insuranceAgentService.GetAllInsuranceAgentsAsync(false)).Dtos
                    : (await directorService.GetAsync(directorId.Value, true)).InsuranceAgents;
            }
        }

        public async Task<IEnumerable<InsuranceAgentGetDTO>> GetAllWithIncludesAsync(int directorId)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await insuranceAgentService.GetAllInsuranceAgentsAsync(true, directorId)).Dtos;
            }
        }
    }
}