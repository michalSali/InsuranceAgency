using AutoMapper;
using BLL.DTOs.People.User;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.Common;
using DAL.Infrastructure.Repositories;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.User.Security;

namespace BLL.Services.User
{
    /// <summary>
    /// User service with CRUD operations and queries
    /// </summary>
    public class UserService : ServiceBase<UserCreateDTO, UserUpdateDTO, UserGetDTO, DAL.Models.User>, IUserService
    {
        private static IPasswordHashing passwordHashing = new PasswordHashing();
        public IPasswordHashing PasswordHashing { get => passwordHashing; }
        
        /// <summary>
        /// Constructs user service with repository, qobject and mapper
        /// </summary>
        /// <param name="repository"> repository with user entity type </param>
        /// <param name="queryObject">query object that queries entity and returns dto </param>
        /// <param name="mapper"> mapper that can map between user DTOs and entities in any order </param>
        public UserService(IRepository<DAL.Models.User> repository,
            IQueryObject<UserGetDTO, DAL.Models.User> queryObject, IMapper mapper)
            : base(repository, queryObject, mapper)
        {
        }

        /// <summary>
        /// Get the user entity by id with includes
        /// </summary>
        /// <param name="id"> id of entity in db, must be >= 0 </param>
        /// <returns> DTO used during Get operations for user </returns>
        protected override UserGetDTO GetWithIncludes(int id)
        {
            var entityDto = repository.GetById(id, nameof(DAL.Models.User.Administrator),
                nameof(DAL.Models.User.Client), nameof(DAL.Models.User.InsuranceAgent),
                nameof(DAL.Models.User.Director));
            return mapper.Map<UserGetDTO>(entityDto);
        }

        public async Task<UserGetDTO> GetByNameAsync(string name, bool include = true)
        {
            var filter = new UserFilterDTO(name);
            if (include)
            {
                filter.Include.Add(UserFilter.IncludeRoles);
            }
            queryObject.AddFilter(filter);
            var result = await queryObject.ExecuteQuery();
            return result.Dtos.FirstOrDefault();
        }

        public async Task<bool> UserExistsAsync(string name)
        {
            return (await GetByNameAsync(name, false)) != null;
        }

        public async Task<UserInfoDTO> AuthorizeAsync(UserLoginDTO entityDto)
        {
            if (entityDto.Name == null)
            {
                return null; // invalid name
            }
            if (entityDto.Password == null)
            {
                return null; // invalid password
            }
            var user = await GetByNameAsync(entityDto.Name);
            if (user == null)
            {
                return null; // not found by name
            }
            var passwordHash = user.PasswordHash;
            var (hash, salt) = passwordHashing.GetPassAndSalt(user.PasswordHash);
            return !passwordHashing.VerifyHashedPassword(hash, salt, entityDto.Password) 
                ? null 
                : mapper.Map<UserInfoDTO>(user);
        }

        public Task<QueryResultDTO<UserGetDTO>> GetAllUsersAsync(bool include = true,
            QueryPagingDTO? queryPagingDto = null)
        {
            if (include)
            {
                var filter = new QueryFilterDTO<DAL.Models.User>();
                filter.Include.Add(UserFilter.IncludeRoles);
                queryObject.AddFilter(filter);
            }
            return queryObject.ExecuteQuery(queryPagingDto);
        }
        
        
    }
}