using BLL.DTOs.People.User;
using BLL.QueryObjects;
using System.Threading.Tasks;
using BLL.QueryObjects.Filters;
using BLL.Services.User.Security;

namespace BLL.Services.User
{
    /// <summary>
    /// Interface for user service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Getter for hashing interface
        /// </summary>
        public IPasswordHashing PasswordHashing { get; }
        
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="entityDto"> create DTO of user</param>
        /// <returns> id of created user, -1 if failed</returns>
        Task<int> CreateAsync(UserCreateDTO entityDto);

        /// <summary>
        /// Authorizes user
        /// </summary>
        /// <param name="entityDto"> login DTO of user </param>
        /// <returns> user info if successful otherwise null</returns>
        Task<UserInfoDTO> AuthorizeAsync(UserLoginDTO entityDto);

        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="id"> id of user in db</param>
        /// <param name="include">whether to include roles</param>
        /// <returns>get DTO of user</returns>
        Task<UserGetDTO> GetAsync(int id, bool include = true);

        /// <summary>
        /// Updates user
        /// </summary>
        /// <param name="entityDto"> update DTO of user </param>
        Task UpdateAsync(UserUpdateDTO entityDto);

        /// <summary>
        /// Deletes user by id
        /// </summary>
        /// <param name="id"> id of user in db</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets user by name
        /// </summary>
        /// <param name="name"> name of user in db</param>
        /// <param name="include">whether to include roles</param>
        /// <returns>get DTO of user, null if not found</returns>
        Task<UserGetDTO> GetByNameAsync(string name, bool include = true);

        /// <summary>
        /// Determines whether user with given name exists in db
        /// </summary>
        /// <param name="name"> name of user </param>
        /// <returns> true if exists otherwise false </returns>
        Task<bool> UserExistsAsync(string name);

        /// <summary>
        /// Gets all users from the db with optional paging
        /// </summary>
        /// <param name="include"> whether to include roles </param>
        /// <param name="queryPagingDto"> optional paging </param>
        /// <returns>query result with get DTOs of users</returns>
        Task<QueryResultDTO<UserGetDTO>> GetAllUsersAsync(bool include = true, QueryPagingDTO? queryPagingDto = null);
    }
}