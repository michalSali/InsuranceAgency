using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs.People.Administrator;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.InsuranceAgent;
using BLL.DTOs.People.User;
using BLL.Facades.Common;
using BLL.QueryObjects;
using BLL.QueryObjects.Filters;
using BLL.Services.Administrator;
using BLL.Services.Client;
using BLL.Services.Director;
using BLL.Services.InsuranceAgent;
using BLL.Services.User;
using DAL.Infrastructure.UnitOfWork;

namespace BLL.Facades.User
{
    public class UserManagementFacade : FacadeBase, IUserManagementFacade
    {
        private readonly IUserService userService;
        private readonly IAdministratorService administratorService;
        private readonly IInsuranceAgentService insuranceAgentService;
        private readonly IDirectorService directorService;
        private readonly IClientService clientService;
        private readonly IMapper mapper;
        public UserManagementFacade(IUnitOfWorkProvider unitOfWorkProvider, IUserService userService,
            IAdministratorService administratorService, IInsuranceAgentService insuranceAgentService,
            IDirectorService directorService, IClientService clientService, IMapper mapper) : base(unitOfWorkProvider)
        {
            this.userService = userService;
            this.administratorService = administratorService;
            this.insuranceAgentService = insuranceAgentService;
            this.directorService = directorService;
            this.clientService = clientService;
            this.mapper = mapper;
        }
        
        public async Task<UserInfoDTO> RegisterAsync(UserRegisterDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if (await userService.UserExistsAsync(entityDto.Name))
                {
                    return null; // duplicit
                }
                // create password hash
                var (hash, salt) = userService.PasswordHashing.CreateHash(entityDto.Password);
                var passwordHash = string.Join(",", hash, salt);
                
                // create UserCreateDTO entity with given password hash
                var toCreateEntityDto = new UserCreateDTO();
                toCreateEntityDto.PasswordHash = passwordHash;
                toCreateEntityDto.Birth = entityDto.Birth;
                toCreateEntityDto.Gender = entityDto.Gender;
                toCreateEntityDto.Name = entityDto.Name;
                
                // create the entity
                var id = await userService.CreateAsync(toCreateEntityDto);
                if (id < 0)
                {
                    return null;
                }
                
                UserInfoDTO result = new UserInfoDTO();
                result.Birth = toCreateEntityDto.Birth;
                result.Gender = toCreateEntityDto.Gender;
                result.Name = toCreateEntityDto.Name;
                await uow.CommitAsync();
                return result;
            }
        }

        public async Task<UserInfoDTO> LoginAsync(UserLoginDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var user = await userService.AuthorizeAsync(entityDto);
                return user;
            }
        }

        public async Task<UserInfoDTO> GetAsync(string name, bool includeRoles = true)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return mapper.Map<UserInfoDTO>(await userService.GetByNameAsync(name, includeRoles));
            }
        }

        public async Task<UserInfoDTO> GetAsync(int id, bool includeRoles = true)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return mapper.Map<UserInfoDTO>(await userService.GetAsync(id, includeRoles));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await userService.GetAsync(id, false)) == null)
                {
                    return false;
                }
                await userService.DeleteAsync(id);
                await uow.CommitAsync();
                return true;
            }
        }
        
        public async Task<bool> UpdateAsync(UserUpdateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var user = await userService.GetAsync(entityDto.Id, false);
                if (user == null)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(entityDto.Password))
                {
                    entityDto.Password = user.PasswordHash;
                } 
                else
                {
                    var (hash, salt) = userService.PasswordHashing.CreateHash(entityDto.Password);
                    var passwordHash = string.Join(",", hash, salt);
                    entityDto.Password = passwordHash;
                }
                
                await userService.UpdateAsync(entityDto);
                await uow.CommitAsync();
                return true;
            }
        }

        private async Task<bool> AddRoleAsync<CreateDtoT, GetDtoT>(CreateDtoT entityDto, int getId,
            Func<int, bool, Task<GetDtoT>> getAsync, Func<CreateDtoT, Task<int>> createAsync)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await userService.GetAsync(getId, false)) == null)
                {
                    return false;
                }

                if ((await getAsync(getId, false)) != null)
                {
                    return false; // role already exists
                }
                await createAsync(entityDto);
                await uow.CommitAsync();
                return true;
            }
        }

        public Task<bool> AddRoleAsync(AdministratorCreateDTO entityDto)
        {
            return AddRoleAsync(entityDto, entityDto.UserId, administratorService.GetAsync,
                administratorService.CreateAsync);
        }

        public Task<bool> AddRoleAsync(ClientCreateDTO entityDto)
        {
            return AddRoleAsync(entityDto, entityDto.UserId, (int id, bool _) => clientService.GetAsync(id),
                clientService.CreateAsync);
        }

        public Task<bool> AddRoleAsync(DirectorCreateDTO entityDto)
        {
            return AddRoleAsync(entityDto, entityDto.UserId, directorService.GetAsync,
                directorService.CreateAsync);
        }

        public Task<bool> AddRoleAsync(InsuranceAgentCreateDTO entityDto)
        {
            return AddRoleAsync(entityDto, entityDto.UserId, insuranceAgentService.GetAsync,
                insuranceAgentService.CreateAsync);
        }

        public async Task<bool> UpdateRoleAsync(DirectorUpdateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await directorService.GetAsync(entityDto.Id, false)) == null)
                {
                    return false;
                }
                await directorService.UpdateAsync(entityDto);
                await uow.CommitAsync();
                return true;
            }
        }

        private async Task<bool> DeleteRoleAsync<GetDtoT>(int id, Func<int, bool, Task<GetDtoT>> get,
            Func<int, Task> delete)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await get(id, false)) == null)
                {
                    return false;
                }
                await delete(id);
                await uow.CommitAsync();
                return true;
            }
        }

        public Task<bool> DeleteAdministratorRoleAsync(int id)
        {
            return DeleteRoleAsync(id, administratorService.GetAsync, administratorService.DeleteAsync);
        }

        public Task<bool> DeleteClientRoleAsync(int id)
        {
            return DeleteRoleAsync(id, (int id, bool _) => clientService.GetAsync(id), clientService.DeleteAsync);
        }

        public Task<bool> DeleteDirectorRoleAsync(int id)
        {
            return DeleteRoleAsync(id, directorService.GetAsync, directorService.DeleteAsync);
        }

        public Task<bool> DeleteInsuranceAgentRoleAsync(int id)
        {
            return DeleteRoleAsync(id, insuranceAgentService.GetAsync, insuranceAgentService.DeleteAsync);
        }
        
        public async Task<bool> DeleteRolesAsync(int id, UserRoleDTO roleFlag)
        {
            var actions = new Dictionary<int, Func<int, Task<bool>>>
            {
                {(int)UserRoleDTO.Administrator, DeleteAdministratorRoleAsync},
                {(int)UserRoleDTO.Client,DeleteClientRoleAsync},
                {(int)UserRoleDTO.Director,DeleteDirectorRoleAsync},
                {(int)UserRoleDTO.InsuranceAgent,DeleteInsuranceAgentRoleAsync}
            };
            bool success = true;
            foreach (var item in actions)
            {
                if (roleFlag.HasFlag((UserRoleDTO) item.Key))
                {
                    success = success && await item.Value(id);
                }
            }

            return success;
        }

        public async Task<IEnumerable<UserInfoDTO>> GetAllAsync(bool include = true,
            QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return mapper.Map<IEnumerable<UserInfoDTO>>(
                    (await userService.GetAllUsersAsync(include, queryPagingDto)).Dtos);
            }
        }
    }
}