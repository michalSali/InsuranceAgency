using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.People.Administrator;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.InsuranceAgent;
using BLL.DTOs.People.User;
using BLL.QueryObjects;

namespace BLL.Facades.User
{
    public interface IUserManagementFacade
    {
        Task<UserInfoDTO> RegisterAsync(UserRegisterDTO entityDto);

        Task<UserInfoDTO> LoginAsync(UserLoginDTO entityDto);

        Task<UserInfoDTO> GetAsync(string name, bool includeRoles=true);
        
        Task<UserInfoDTO> GetAsync(int id, bool includeRoles=true);

        Task<bool> DeleteAsync(int id);
        
        Task<bool> UpdateAsync(UserUpdateDTO entityDto);

        Task<bool> AddRoleAsync(AdministratorCreateDTO entityDto);
        
        Task<bool> AddRoleAsync(ClientCreateDTO entityDto);
        
        Task<bool> AddRoleAsync(DirectorCreateDTO entityDto);
        
        Task<bool> AddRoleAsync(InsuranceAgentCreateDTO entityDto);

        Task<bool> UpdateRoleAsync(DirectorUpdateDTO entityDto);
        
        Task<bool> DeleteAdministratorRoleAsync(int id);
        
        Task<bool> DeleteClientRoleAsync(int id);
        
        Task<bool> DeleteDirectorRoleAsync(int id);
        
        Task<bool> DeleteInsuranceAgentRoleAsync(int id);

        Task<bool> DeleteRolesAsync(int id, UserRoleDTO roleFlag);

        Task<IEnumerable<UserInfoDTO>> GetAllAsync(bool include = true, QueryPagingDTO? queryPagingDto = null);
    }
}