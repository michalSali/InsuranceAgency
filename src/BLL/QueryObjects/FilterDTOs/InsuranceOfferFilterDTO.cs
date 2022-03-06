using System.Linq;
using DAL.Models;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// Filter DTO to be used for insurance offers
    /// </summary>
    public class InsuranceOfferFilterDTO : QueryFilterDTO<InsuranceOffer>
    {
        /// <summary>
        /// Constructs DTO that can filter out active and sort
        /// </summary>
        /// <param name="active"> If ture then use filtering of active </param>
        /// <param name="sort"> If true then sort by date </param>
        public InsuranceOfferFilterDTO(bool active, bool sort)
        {
            if (active)
            {
                Filter.Add(Filters.InsuranceOffersFilter.FilterActive);
            }

            if (sort)
            {
                Sort.Add(Filters.InsuranceOffersFilter.SortByDate);
            }
        }
        
        /// <summary>
        /// Constructs DTO that can filter out by director id and filter active and sort
        /// </summary>
        /// <param name="directorId"> id of director to filter on </param>
        /// <param name="active"> If ture then use filtering of active </param>
        /// <param name="sort"> If true then sort by date </param>
        public InsuranceOfferFilterDTO(int directorId, bool active, bool sort) : this(active, sort)
        {
            Filter.Add(queryable => queryable.Where(offer => offer.DirectorId == directorId));
        }
    }
}