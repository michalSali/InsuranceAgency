using AutoMapper;
using BLL.DTOs;
using BLL.QueryObjects;
using DAL.Infrastructure.Repositories;
using DAL.Models;
using System.Threading.Tasks;

namespace BLL.Services.Common
{
    /// <summary>
    /// Abstract service base class that implements base CRUD functionality for a service
    /// </summary>
    /// <typeparam name="TCreateDTO"> Type of DTO to use during Create operations </typeparam>
    /// <typeparam name="TUpdateDTO"> Type of DTO to use during Update operations </typeparam>
    /// <typeparam name="TGetDTO"> Type of DTO to use during Get operations </typeparam>
    /// <typeparam name="TEntity"> Type of database entity </typeparam>
    public abstract class ServiceBase<TCreateDTO, TUpdateDTO, TGetDTO, TEntity>
    where TCreateDTO : class, new()
    where TUpdateDTO : DTOBase
    where TGetDTO : DTOBase
    where TEntity : class, IEntity
    {
        // repository with given entity type
        protected readonly IRepository<TEntity> repository;

        // query object that queries entity and returns dto 
        protected readonly IQueryObject<TGetDTO, TEntity> queryObject;

        // mapper that can map between DTOs and entities in any order
        protected readonly IMapper mapper;

        /// <summary>
        /// Constructs Service base with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with given entity type </param>
        /// <param name="queryObject">query object that queries entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between DTOs and entities in any order </param>
        public ServiceBase(IRepository<TEntity> repository,
            IQueryObject<TGetDTO, TEntity> queryObject, IMapper mapper)
        {
            this.repository = repository;
            this.queryObject = queryObject;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get the entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected abstract TGetDTO GetWithIncludes(int id);

        /// <summary>
        /// Asynchronously creates entity
        /// </summary>
        /// <param name="entityDto"> entity to create </param>
        /// <returns> id of entity created, -1 in case of error </returns>
        public virtual async Task<int> CreateAsync(TCreateDTO entityDto)
        {
            var entity = mapper.Map<TEntity>(entityDto);
            await repository.InsertAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// Gets entity by id with optional includes
        /// </summary>
        /// <param name="id"> id of entity in db </param>
        /// <param name="include"> whether to include </param>
        /// <returns> DTO used during Get operations of given entity </returns>
        public virtual Task<TGetDTO> GetAsync(int id, bool include = true)
        {
            return Task.FromResult(include ? GetWithIncludes(id) : mapper.Map<TGetDTO>(repository.GetById(id)));
        }

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entityDto"> entity to update in db </param>
        public virtual Task UpdateAsync(TUpdateDTO entityDto)
        {
            var entity = mapper.Map<TEntity>(entityDto);
            repository.Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        /// <param name="id"> id of entity to delete </param>
        public virtual async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }
    }
}