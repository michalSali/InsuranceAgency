using DAL.Models;
using System.Linq;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// DTO used to filter insurances
    /// </summary>
    public class InsuranceFilterDTO : QueryFilterDTO<ClientInsurance>
    {
        /// <summary>
        /// Constructs DTO for insurances that can be used to filter active and sort by date
        /// </summary>
        /// <param name="active">If true then filter active</param>
        /// <param name="sort">If true then sort by date</param>
        public InsuranceFilterDTO(bool active, bool sort)
        {
            if (active)
            {
                Filter.Add(Filters.InsuranceFilter.FilterActive);
            }

            if (sort)
            {
                Sort.Add(Filters.InsuranceFilter.SortByDate);
            }
        }
        
        /// <summary>
        /// Constructs DTO for insurances that can be used to filter active, filter by client id, and sort by date
        /// </summary>
        /// <param name="clientId"> id of client to filter</param>
        /// <param name="active">If true then filter active</param>
        /// <param name="sort">If true then sort by date</param>
        public InsuranceFilterDTO(int clientId, bool active, bool sort) : this(active, sort)
        {
            Filter.Add(queryable => queryable.Where(insurance => insurance.ClientId == clientId));
        }
    }
}