using AutoMapper;
using BLL.DTOs.Objects.Gear;
using BLL.QueryObjects;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;

namespace BLL.Services.Gear
{
    /// <summary>
    /// Gear service with CRUD operations and queries
    /// </summary>
    public class GearService : ServiceBase<GearCreateDTO, GearUpdateDTO, GearGetDTO, DAL.Models.Gear>, IGearService
    {
        /// <summary>
        /// Constructs gear service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with given entity type </param>
        /// <param name="queryObject">query object that queries entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between DTOs and entities in any order </param>
        public GearService(IRepository<DAL.Models.Gear> repository,
            IQueryObject<GearGetDTO, DAL.Models.Gear> queryObject,
            IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the gear entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override GearGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.Gear.Client));
            return mapper.Map<GearGetDTO>(entity);
        }
    }
}