using AutoMapper;
using BLL.DTOs.People.Administrator;
using BLL.QueryObjects;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;

namespace BLL.Services.Administrator
{
    /// <summary>
    /// Administrator service that does not contain update mechanisms
    /// </summary>
    public class AdministratorService : ServiceBase<AdministratorCreateDTO, AdministratorGetDTO,
        AdministratorGetDTO, DAL.Models.Administrator>, IAdministratorService
    {
        /// <summary>
        /// Constructs
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="queryObject"></param>
        /// <param name="mapper"></param>
        public AdministratorService(IRepository<DAL.Models.Administrator> repository, IQueryObject<AdministratorGetDTO,
            DAL.Models.Administrator> queryObject, IMapper mapper) : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Overrides include method to include user
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Get</returns>
        protected override AdministratorGetDTO GetWithIncludes(int id)
        {
            var entity = repository.GetById(id, nameof(DAL.Models.Administrator.User));
            return mapper.Map<AdministratorGetDTO>(entity);
        }
    }
}