using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for insurance offers
    /// </summary>
    public static class InsuranceOffersFilter
    {
        public static IOrderedQueryable<InsuranceOffer> SortByDate(IQueryable<InsuranceOffer> queryable)
        {
            return queryable.OrderBy(offer => offer.CreationDate);
        }

        public static IQueryable<InsuranceOffer> FilterActive(IQueryable<InsuranceOffer> queryable)
        {
            return queryable.Where(offer => offer.ExpirationDate == null || offer.ExpirationDate.Value > DateTime.Now);
        }

        public static IQueryable<InsuranceOffer> IncludeEverything(IQueryable<InsuranceOffer> queryable)
        {
            return queryable.Include(offer => offer.ClientInsurances);          
        }
    }
}