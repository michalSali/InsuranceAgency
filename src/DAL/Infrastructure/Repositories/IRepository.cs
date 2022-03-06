using DAL.Models;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repositories
{
    /// <summary>
    /// Interface for repository pattern
    /// </summary>
    /// <typeparam name="TEntity"> Type of entity class used as database entity </typeparam>
    public interface IRepository<out TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets entity by id with supplied includes
        /// </summary>
        /// <param name="id"> id to find entity by </param>
        /// <param name="includes"> includes wanted, can be specified like nameof(User.Client) for example </param>
        /// <returns> Found entity, null if not found </returns>
        TEntity GetById(int id, params string[] includes);

        /// <summary>
        /// Gets entity by id 
        /// </summary>
        /// <param name="id"> id to find entity by </param>
        /// <returns> Found entity, null if not found </returns>
        TEntity GetById(int id);

        /// <summary>
        /// Asynchronously inserts an entity into database
        /// </summary>
        /// <param name="entity"> valid entity used in database, must be castable to TEntity </param>
        Task InsertAsync(IEntity entity);

        /// <summary>
        /// Asynchronously deletes entity by id
        /// </summary>
        /// <param name="id"> id that is in database </param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Synchronously deletes entity in db
        /// </summary>
        /// <param name="entityToDelete"> entity to delete, must be castable to TEntity </param>
        void Delete(IEntity entityToDelete);

        /// <summary>
        /// Updates entity in db
        /// </summary>
        /// <param name="entityToUpdate"> entity to update, must be castable to TEntity </param>
        void Update(IEntity entityToUpdate);
    }
}