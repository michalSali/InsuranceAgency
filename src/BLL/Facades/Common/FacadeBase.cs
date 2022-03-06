using DAL.Infrastructure.UnitOfWork;

namespace BLL.Facades.Common
{
    /// <summary>
    /// Facade base that contains UOWProvider
    /// </summary>
    public abstract class FacadeBase
    {
        protected readonly IUnitOfWorkProvider unitOfWorkProvider;

        /// <summary>
        /// Constructs facade base with given UOWProvider
        /// </summary>
        /// <param name="unitOfWorkProvider"> UOWProvider, non-null </param>
        protected FacadeBase(IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
        }
    }
}