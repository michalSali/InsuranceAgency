using AutoMapper;
using BLL.DTOs.Objects.BackgroundInfo;
using BLL.QueryObjects;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;

namespace BLL.Services.BackgroundInfo
{
    /// <summary>
    /// Administrator service for base CRUD operations
    /// </summary>
    public class BackgroundInfoService : ServiceBase<BackgroundInfoCreateDTO, BackgroundInfoUpdateDTO,
        BackgroundInfoGetDTO, DAL.Models.BackgroundInfo>, IBackgroundInfoService
    {
        /// <summary>
        /// Constructs background info service base with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with background info entity type </param>
        /// <param name="queryObject">query object that queries background info entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between background info DTOs and entities in any order </param>
        public BackgroundInfoService(IRepository<DAL.Models.BackgroundInfo> repository,
            IQueryObject<BackgroundInfoGetDTO, DAL.Models.BackgroundInfo> queryObject,
            IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the background info entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations </returns>
        protected override BackgroundInfoGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.BackgroundInfo.Client));
            return mapper.Map<BackgroundInfoGetDTO>(entity);
        }
    }
}