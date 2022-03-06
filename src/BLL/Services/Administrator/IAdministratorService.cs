using BLL.DTOs.People.Administrator;
using System.Threading.Tasks;

namespace BLL.Services.Administrator
{
    /// <summary>
    /// Interface for administrator service
    /// </summary>
    public interface IAdministratorService
    {
        /// <summary>
        /// Creates new administrator
        /// </summary>
        /// <param name="entityDto"> create DTO of administrator entity </param>
        /// <returns> id of new entity, in case of error -1 </returns>
        Task<int> CreateAsync(AdministratorCreateDTO entityDto);

        /// <summary>
        /// Gets entity by id with optional include
        /// </summary>
        /// <param name="id"> id of entity in db </param>
        /// <param name="include"> whether to include user </param>
        /// <returns>get DTO of administrator </returns>
        Task<AdministratorGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        /// <param name="id"> id of entity in db </param>
        Task DeleteAsync(int id);
    }
}