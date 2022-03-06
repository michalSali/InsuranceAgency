using BLL.DTOs.Objects.Gear;
using System.Threading.Tasks;

namespace BLL.Services.Gear
{
    /// <summary>
    /// Interface for gear service
    /// </summary>
    public interface IGearService
    {
        /// <summary>
        /// Creates new gear
        /// </summary>
        /// <param name="entityDto"> create DTO of entity </param>
        /// <returns> id of new gear, -1 if failed </returns>
        Task<int> CreateAsync(GearCreateDTO entityDto);

        /// <summary>
        /// Gets gear by id
        /// </summary>
        /// <param name="id"> id of gear </param>
        /// <param name="include"> whether to include</param>
        /// <returns>null if not found otherwise get DTO of gear</returns>
        Task<GearGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Updates gear
        /// </summary>
        /// <param name="entityDto"> update DTO gear entity </param>
        Task UpdateAsync(GearUpdateDTO entityDto);

        /// <summary>
        /// Deletes gear by id
        /// </summary>
        /// <param name="id"> id of entity to delete </param>
        Task DeleteAsync(int id);
    }
}