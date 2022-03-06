using DAL.Infrastructure.Repositories;
using DAL.Models;
using System;
using System.Threading.Tasks;

namespace DAL.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Interface for unit of work pattern, impelements disposable interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets repository with TEntity type
        /// </summary>
        /// <typeparam name="TEntity"> class type used as database entity </typeparam>
        /// <returns> repository, new if not found </returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        /// <summary>
        /// Commits asynchronously
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Commits synchronously
        /// </summary>
        void Commit();

        /// <summary>
        /// Registers an action to be performed after commit
        /// </summary>
        /// <param name="action"> valid Action to be performed </param>
        void RegisterActionAfterCommit(Action action);
    }
}