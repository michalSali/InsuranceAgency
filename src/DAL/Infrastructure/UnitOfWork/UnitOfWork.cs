using DAL.Infrastructure.Repositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Implements unit of work interface with DbContext
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }
        private List<Action> afterCommitActions = new List<Action>();
        private HashSet<IRepository<IEntity>> repositories = new HashSet<IRepository<IEntity>>();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            var repository = repositories.OfType<IRepository<TEntity>>().FirstOrDefault();
            if (repository == null)
            {
                repository = new GenericRepository<TEntity>(Context);
                repositories.Add(repository);
            }
            return repository;
        }

        /// <summary>
        /// Constructs unit of work from DbContext
        /// </summary>
        /// <param name="context"> valid DbContext </param>
        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        // runs all after commit actions
        private void RunAfterCommitActions()
        {
            foreach (var action in afterCommitActions)
                action();
            afterCommitActions.Clear();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
            RunAfterCommitActions();
        }

        public void Commit()
        {
            Context.SaveChanges();
            RunAfterCommitActions();
        }

        public void RegisterActionAfterCommit(Action action)
        {
            afterCommitActions.Add(action);
        }

        private bool disposed = false;

        // disposes safely
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}


