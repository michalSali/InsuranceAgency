using System.Linq;
using BLL.DTOs.Objects.ConflictInvolvement;
using DAL.Models;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// DTO used to filter conflict involvements
    /// </summary>
    public class ConflictInvolvementFilterDTO : QueryFilterDTO<ConflictInvolvement>
    {
        /// <summary>
        /// Constructs DTO to filter conflict involvements based on client and conflict id
        /// </summary>
        /// <param name="clientId"> id of client to filter on </param>
        /// <param name="conflictId"> id of conflict to filter on </param>
        public ConflictInvolvementFilterDTO(int clientId, int conflictId)
        {
            Filter.Add(queryable => queryable.Where(
                involvement => involvement.ClientId == clientId && involvement.ConflictId == conflictId));
        }

        /// <summary>
        /// Constructs DTO to filter conflict involvements based on client id
        /// </summary>
        /// <param name="clientId"> id of client to filter on </param>
        public ConflictInvolvementFilterDTO(int clientId)
        {
            Filter.Add(queryable => queryable.Where(
                involvement => involvement.ClientId == clientId));
        }
    }
}