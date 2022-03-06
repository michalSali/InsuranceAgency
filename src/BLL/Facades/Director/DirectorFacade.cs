using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.People.Director;
using BLL.Facades.Common;
using BLL.QueryObjects;
using BLL.Services.Director;
using DAL.Infrastructure.UnitOfWork;

namespace BLL.Facades.Director
{
    public class DirectorFacade : FacadeBase, IDirectorFacade
    {
        private readonly IDirectorService directorService;
        public DirectorFacade(IUnitOfWorkProvider unitOfWorkProvider, IDirectorService directorService) : base(unitOfWorkProvider)
        {
            this.directorService = directorService;
        }

        public async Task<DirectorGetDTO> GetAsync(int id, bool include = false)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await directorService.GetAsync(id, include);
            }
        }

        public async Task<IEnumerable<DirectorGetDTO>> GetAllAsync(QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await directorService.GetAllDirectorsAsync(false, queryPagingDto)).Dtos;
            }
        }
    }
}