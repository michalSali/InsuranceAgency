using System.Collections.Generic;

namespace BLL.QueryObjects
{
    /// <summary>
    /// Query result with paging information and DTOs queried
    /// </summary>
    /// <typeparam name="EntityDTO"></typeparam>
    public class QueryResultDTO<EntityDTO>
    {
        /// <summary>
        /// Queried DTOs
        /// </summary>
        public IEnumerable<EntityDTO> Dtos { get; }

        /// <summary>
        /// Optional paging info
        /// </summary>
        public QueryPagingDTO? QueryPagingDto { get;  }

        /// <summary>
        /// Constructs the Query result DTO
        /// </summary>
        /// <param name="dtos"> DTOs </param>
        /// <param name="queryPagingDto"> optional paging Dto </param>
        public QueryResultDTO(IEnumerable<EntityDTO> dtos, QueryPagingDTO? queryPagingDto = null)
        {
            Dtos = dtos;
            QueryPagingDto = queryPagingDto;
        }
    }
}