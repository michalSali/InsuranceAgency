using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.People.Director;
using BLL.QueryObjects;

namespace BLL.Facades.Director
{
    public interface IDirectorFacade
    {
        Task<DirectorGetDTO> GetAsync(int id, bool include);

        Task<IEnumerable<DirectorGetDTO>> GetAllAsync(QueryPagingDTO? queryPagingDto = null);
    }
}