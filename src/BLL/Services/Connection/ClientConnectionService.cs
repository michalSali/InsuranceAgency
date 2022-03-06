using AutoMapper;
using BLL.DTOs.Objects.ClientConnection;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace BLL.Services.Connection
{
    /// <summary>
    /// Client connection service with CRUD operations and queries
    /// </summary>
    public class ClientConnectionService : ServiceBase<ClientConnectionCreateDTO, ClientConnectionUpdateDTO,
        ClientConnectionGetDTO, DAL.Models.ClientConnection>, IClientConnectionService
    {
        /// <summary>
        /// Constructs client connection service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with client connection entity type </param>
        /// <param name="queryObject">query object that queries client connection entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between client connection DTOs and entities in any order </param>
        public ClientConnectionService(IRepository<DAL.Models.ClientConnection> repository,
            IQueryObject<ClientConnectionGetDTO, DAL.Models.ClientConnection> queryObject,
            IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the client connection entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override ClientConnectionGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.ClientConnection.Object),
                nameof(DAL.Models.ClientConnection.Subject));
            return mapper.Map<ClientConnectionGetDTO>(entity);
        }

        public Task<QueryResultDTO<ClientConnectionGetDTO>> GetAllConnectionsAsync(int? clientId,
            QueryPagingDTO? queryPagingDto = null)
        {
            var filter = (clientId != null) ? new ClientConnectionFilterDTO(clientId.Value) 
                : new ClientConnectionFilterDTO();
            filter.Include.Add(ClientConnectionsFilter.IncludeParticipants);
            queryObject.AddFilter(filter);
            return queryObject.ExecuteQuery(queryPagingDto);
        }
    }
}