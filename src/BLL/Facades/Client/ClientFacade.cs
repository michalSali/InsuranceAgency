using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.DTOs.Objects.BackgroundInfo;
using BLL.DTOs.Objects.ClientConnection;
using BLL.DTOs.Objects.Gear;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.User;
using BLL.Facades.Common;
using BLL.QueryObjects;
using BLL.Services.BackgroundInfo;
using BLL.Services.Client;
using BLL.Services.Connection;
using BLL.Services.Gear;
using BLL.Services.User;
using DAL.Infrastructure.UnitOfWork;

namespace BLL.Facades.Client
{
    public class ClientFacade : FacadeBase, IClientFacade
    {
        private readonly IClientService clientService;
        private readonly IUserService userService;
        private readonly IBackgroundInfoService backgroundInfoService;
        private readonly IGearService gearService;
        private readonly IClientConnectionService clientConnectionService;
        
        public ClientFacade(IUnitOfWorkProvider unitOfWorkProvider, IClientService clientService,
            IUserService userService, IBackgroundInfoService backgroundInfoService, IGearService gearService,
            IClientConnectionService connectionService) : base(unitOfWorkProvider)
        {
            this.clientService = clientService;
            this.userService = userService;
            this.backgroundInfoService = backgroundInfoService;
            this.gearService = gearService;
            this.clientConnectionService = connectionService;
        }

        public async Task<int> CreateNewAsync(int insuranceAgentId, UserCreateDTO entityUserInfoDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if (await userService.UserExistsAsync(entityUserInfoDto.Name))
                {
                    return -1;
                }
                var entityDto = new ClientCreateDTO();
                entityDto.InsuranceAgentId = insuranceAgentId;
                entityDto.UserId = await userService.CreateAsync(entityUserInfoDto);
                if (entityDto.UserId < 0)
                {
                    return -1; // error
                }
                return await clientService.CreateAsync(entityDto);
            }
        }

        public async Task<ClientGetDTO> GetAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await clientService.GetAsync(id);
            }
        }

        public async Task<ClientGetDTO> GetWithExtendedInfoAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await clientService.GetWithExtendedInfoAsync(id);
            }
        }

        public async Task<ClientGetDTO> GetWithAllInfoAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await clientService.GetWithAllInfoAsync(id);
            }
        }

        public async Task<ClientGetAggregatedDTO> GetAggregatedAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await clientService.GetWithAllInfoAggregatedAsync(id);
            }
        }

        public Task<int> AddBackgroundInfoAsync(BackgroundInfoCreateDTO entityDto)
        {
            return AddAsync(entityDto, entityDto.ClientId, backgroundInfoService.CreateAsync);
        }

        public Task<bool> UpdateBackgroundInfoAsync(BackgroundInfoUpdateDTO entityDto)
        {
            return UpdateAsync(entityDto, backgroundInfoService.UpdateAsync, backgroundInfoService.GetAsync);
        }

        public Task<bool> DeleteBackgroundInfoAsync(int id)
        {
            return DeleteAsync(id, backgroundInfoService.DeleteAsync, backgroundInfoService.GetAsync);
        }

        public Task<BackgroundInfoGetDTO> GetBackgroundInfoAsync(int id)
        {
            return backgroundInfoService.GetAsync(id);
        }

        public Task<int> AddGearAsync(GearCreateDTO entityDto)
        {
            return AddAsync(entityDto, entityDto.ClientId, gearService.CreateAsync);
        }

        public Task<bool> UpdateGearAsync(GearUpdateDTO entityDto)
        {
            return UpdateAsync(entityDto, gearService.UpdateAsync, gearService.GetAsync);
        }

        public Task<bool> DeleteGearAsync(int id)
        {
            return DeleteAsync(id, gearService.DeleteAsync, gearService.GetAsync);
        }

        public Task<int> AddClientConnectionAsync(ClientConnectionCreateDTO entityDto)
        {
            return AddAsync(entityDto, entityDto.ObjectId, clientConnectionService.CreateAsync, entityDto.SubjectId);
        }

        public Task<bool> UpdateClientConnectionAsync(ClientConnectionUpdateDTO entityDto)
        {
            return UpdateAsync(entityDto, clientConnectionService.UpdateAsync, clientConnectionService.GetAsync);
        }

        public Task<bool> DeleteClientConnectionAsync(int id)
        {
            return DeleteAsync(id, clientConnectionService.DeleteAsync, clientConnectionService.GetAsync);
        }

        public Task<ClientConnectionGetDTO> GetClientConnectionAsync(int id)
        {
            return clientConnectionService.GetAsync(id);
        }

        public async Task<bool> ChangeAgentAsync(int clientId, int newAgentId)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var client = await clientService.GetAsync(clientId);
                if (client == null)
                {
                    return false; // client with given id does not exist
                }

                var updateDto = new ClientUpdateDTO();
                updateDto.Id = client.Id;
                updateDto.InsuranceAgentId = newAgentId;
                await clientService.UpdateAsync(updateDto);
                await uow.CommitAsync();
                return true;
            }
        }

        public async Task<IEnumerable<ClientGetDTO>> GetAllClientsAsync(
            bool extendedInfo=true, int? agentId=null, QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (extendedInfo)
                    ? (await clientService.GetAllWithExtendedInfoAsync(agentId, queryPagingDto)).Dtos
                    : (await clientService.GetAllAsync(agentId, queryPagingDto)).Dtos;
                   
            }
        }

        public async Task<IEnumerable<ClientGetAggregatedDTO>> GetAllClientsAggregatedAsync(
            int? agentId=null, QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await clientService.GetAllWithAllInfoAggregatedAsync(agentId, queryPagingDto)).Dtos;
            }
        }

        public async Task<IEnumerable<ClientGetAggregatedDTO>> GetAllDirectorsClientsAggregatedAsync(
            int directorId, QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await clientService.GetAllWithAllInfoAggregatedByDirectorAsync(directorId, queryPagingDto)).Dtos;
            }
        }

        // used to add a generic entity that is tied to client
        private async Task<int> AddAsync<TCreateDto>(TCreateDto entityDto, int getId, 
            Func<TCreateDto, Task<int>> createAsync, int? optionalGetId = null)
            where TCreateDto : class, new()
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await clientService.GetAsync(getId)) == null)
                {
                    return -1; // client with given id does not exist
                }

                // check second optional id in client service
                if (optionalGetId != null && (await clientService.GetAsync(optionalGetId.Value)) == null)
                {
                    return -1; // client with given id does not exist
                }
                
                var id =  await createAsync(entityDto);
                await uow.CommitAsync();
                return id;
            }
        }

        // used to update a generic entity tied to client
        private async Task<bool> UpdateAsync<TUpdateDto, TGetDto>(TUpdateDto entityDto, Func<TUpdateDto,
            Task> updateAsync, Func<int, bool, Task<TGetDto>> getAsync)
            where TUpdateDto : DTOBase, new()
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await getAsync(entityDto.Id, false)) == null)
                {
                    return false; // not in database
                }
                await updateAsync(entityDto);
                await uow.CommitAsync();
            }

            return true;
        }

        // used to delete a generic entity tied to client
        private async Task<bool> DeleteAsync<TGetDto>(int id, Func<int, Task> deleteAsync,
            Func<int, bool, Task<TGetDto>> getAsync)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await getAsync(id, false)) == null)
                {
                    return false; // not in database
                }
                await deleteAsync(id);
                await uow.CommitAsync();
            }

            return true;
        }
    }
}