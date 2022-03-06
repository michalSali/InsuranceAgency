using System.Linq;
using DAL.Models;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// DTO used to filter conflicts
    /// </summary>
    public class ConflictFilterDTO : QueryFilterDTO<Conflict>
    {
        /// <summary>
        /// Constructs DTO to filter conflicts based on activity and sort by date
        /// </summary>
        /// <param name="active"> if true then filter active </param>
        /// <param name="sort"> if true then sort by date </param>
        public ConflictFilterDTO(bool active, bool sort)
        {
            if (active)
            {
                Filter.Add(Filters.ConflictFilter.FilterActive);
            }

            if (sort)
            {
                Sort.Add(Filters.ConflictFilter.SortByDate);
            }
        }
        
        /// <summary>
        /// Constructs DTO to filter conflicts based on director id, activity and sort by date
        /// </summary>
        /// <param name="directorId"> id to filter on </param>
        /// <param name="active"> if true then filter active </param>
        /// <param name="sort"> if true then sort by date </param>
        public ConflictFilterDTO(int directorId, bool active, bool sort) : this(active, sort)
        {
            Filter.Add(queryable => queryable.Where(conflict => conflict.DirectorId == directorId));
        }
    }
}