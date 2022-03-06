using DAL.Models;
using System.Linq;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// DTO used to filter client by insurance agent id
    /// </summary>
    public class ClientFilterByInsuranceAgentIdDTO : QueryFilterDTO<Client>
    {
        public ClientFilterByInsuranceAgentIdDTO(int? insuranceAgentId)
        {
            if (insuranceAgentId != null)
            {
                Filter.Add(queryable => queryable.Where(
                    client => client.InsuranceAgentId == insuranceAgentId.Value));
            }
        }
    }
}