using System;

namespace DAL.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Interface for unit of work provider pattern
    /// </summary>
    public interface IUnitOfWorkProvider : IDisposable
    {
        /// <summary>
        /// Creates new unit of work
        /// </summary>
        /// <returns> unit of work </returns>
        IUnitOfWork Create();

        /// <summary>
        /// Gets unit of work, throws exception if UOW was not created yer
        /// </summary>
        /// <returns> unit of work </returns>
        IUnitOfWork GetUnitOfWorkInstance();
    }
}