using Microsoft.EntityFrameworkCore;

namespace DAL.DbContextFactory
{
    /// <summary>
    /// Wrapper that is used as a factory to construct <c>TConstructContext</c> context and then convert it to DbContext.
    /// Implements IDbContextFactory<DbContext>, but constructs TConstructContext
    /// </summary>
    /// <typeparam name="TConstructContext"> Own context type that must be derived from DbContext </typeparam>
    public class GenericDbContextFactoryWrapper<TConstructContext> : IDbContextFactory<DbContext>
    where TConstructContext : DbContext
    {
        private IDbContextFactory<TConstructContext> innerFactory;
        
        /// <summary>
        /// Constructs the wrapper factory with given inner db factory
        /// </summary>
        /// <param name="innerFactory"> valid DbContext Factory</param>
        public GenericDbContextFactoryWrapper(IDbContextFactory<TConstructContext> innerFactory)
        {
            this.innerFactory = innerFactory;
        }
        
        /// <summary>
        /// Creates DbContext with inner factory and then casts it to DbContext
        /// </summary>
        /// <returns> valid DbContext object </returns>
        public DbContext CreateDbContext()
        {
            return innerFactory.CreateDbContext();
        }
    }
}