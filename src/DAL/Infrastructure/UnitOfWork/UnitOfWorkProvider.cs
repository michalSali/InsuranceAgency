using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace DAL.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Implements unit of work provider with DbContextFactory
    /// </summary>
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        private readonly IDbContextFactory<DbContext> dbContextFactory;
        private readonly AsyncLocal<IUnitOfWork> unitOfWorkLocal = new AsyncLocal<IUnitOfWork>();

        /// <summary>
        /// Constructs UOWProvider from DbContextFactory that constructs DbContext
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public UnitOfWorkProvider(IDbContextFactory<DbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IUnitOfWork Create()
        {
            unitOfWorkLocal.Value = new UnitOfWork(dbContextFactory?.CreateDbContext() ?? throw new ArgumentNullException(
                "UOW db context factory cant be null."));
            return unitOfWorkLocal.Value;
        }

        public IUnitOfWork GetUnitOfWorkInstance()
        {
            return unitOfWorkLocal.Value ?? throw new InvalidOperationException("UoWLocal Not created");
        }

        public void Dispose()
        {
            if (unitOfWorkLocal.Value != null)
            {
                unitOfWorkLocal.Value.Dispose();
                unitOfWorkLocal.Value = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}