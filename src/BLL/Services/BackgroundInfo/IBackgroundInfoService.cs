using BLL.DTOs.Objects.BackgroundInfo;
using System.Threading.Tasks;

namespace BLL.Services.BackgroundInfo
{
    /// <summary>
    /// Defines interface for background service
    /// </summary>
    public interface IBackgroundInfoService
    {
        /// <summary>
        /// Creates new background info
        /// </summary>
        /// <param name="entityDto"> create DTO of background info entity </param>
        /// <returns> id of new background info, -1 if not found </returns>
        Task<int> CreateAsync(BackgroundInfoCreateDTO entityDto);

        /// <summary>
        /// Gets background info by id
        /// </summary>
        /// <param name="id"> id of background info in db </param>
        /// <param name="include"> whether to include</param>
        /// <returns> get DTO of background info entity </returns>
        Task<BackgroundInfoGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Updates background info
        /// </summary>
        /// <param name="entityDto"> update DTO of background info entity </param>
        Task UpdateAsync(BackgroundInfoUpdateDTO entityDto);

        /// <summary>
        /// Deletes background info by id
        /// </summary>
        /// <param name="id"> id of background info to delete</param>
        Task DeleteAsync(int id);
    }
}