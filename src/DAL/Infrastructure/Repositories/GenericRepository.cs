using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DAL.Infrastructure.UnitOfWork;

namespace DAL.Infrastructure.Repositories
{
    /// <summary>
    /// GenericRepository that uses either supplied context or supplied UOWProvider.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly IUnitOfWorkProvider provider = null;
        private readonly DbContext context = null;
        
        /// <summary>
        /// Gets the <see cref="DbContext"/>.
        /// </summary>
        protected DbContext Context =>
            context ?? ((UnitOfWork.UnitOfWork)provider.GetUnitOfWorkInstance()).Context;

        /// <summary>
        /// Constructs repository with given context
        /// </summary>
        /// <param name="context"> valid DbContext </param>
        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Constructs repository with given UOWProvider
        /// </summary>
        /// <param name="provider"> valid UOWProvider </param>
        public GenericRepository(IUnitOfWorkProvider provider)
        {
            this.provider = provider;
        }

        public virtual TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(int id, params string[] includes)
        {
            if (includes == null || includes.Length == 0)
            {
                return GetById(id);
            }
            var query = Context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.SingleOrDefault(entity => entity.Id.Equals(id));
        }

        public async virtual Task InsertAsync(IEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity as TEntity);
        }

        public async virtual Task DeleteAsync(int id)
        {
            TEntity entityToDelete = await Context.Set<TEntity>().FindAsync(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(IEntity entityToDelete)
        {
            var entity = entityToDelete as TEntity;
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(IEntity entityToUpdate)
        {
            var entity = entityToUpdate as TEntity;
            var foundEntity = Context.Set<TEntity>().Find(entity.Id);
            Context.Entry(foundEntity).CurrentValues.SetValues(entity);
            //Context.Set<TEntity>().Attach(entity);
            //Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
