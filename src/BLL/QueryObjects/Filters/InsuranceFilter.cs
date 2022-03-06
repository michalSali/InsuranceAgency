using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BLL.QueryObjects.Filters
{
    /// <summary>
    /// Filtering, sorting and including functions used for insurances
    /// </summary>
    public static class InsuranceFilter
    {
        public static IOrderedQueryable<ClientInsurance> SortByDate(IQueryable<ClientInsurance> queryable)
        {
            return queryable.OrderBy(offer => offer.CreationDate);
        }

        public static IQueryable<ClientInsurance> FilterActive(IQueryable<ClientInsurance> queryable)
        {
            return queryable.Where(offer => offer.ExpirationDate == null || offer.ExpirationDate.Value > DateTime.Now);
        }

        public static IQueryable<ClientInsurance> IncludeEverything(IQueryable<ClientInsurance> queryable)
        {            
            return queryable.Include(d => d.Client)
                .Include(d => d.InsuranceOffer);
        }
    }
}