using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.Objects.ConflictInvolvement;
using BLL.DTOs.Objects.ConflictRecord;
using BLL.DTOs.People.Client;
using BLL.Facades.Common;
using BLL.QueryObjects;
using BLL.Services.Conflict;
using BLL.Services.ConflictInvolvement;
using BLL.Services.ConflictRecord;
using DAL.Infrastructure.UnitOfWork;

namespace BLL.Facades.Conflict
{
    public class ConflictFacade : FacadeBase, IConflictFacade
    {
        private readonly IConflictService conflictService;
        private readonly IConflictInvolvementService conflictInvolvementService;
        private readonly IConflictRecordService conflictRecordService;
        
        public ConflictFacade(IUnitOfWorkProvider unitOfWorkProvider, IConflictService conflictService,
            IConflictInvolvementService conflictInvolvementService,
            IConflictRecordService conflictRecordService) : base(unitOfWorkProvider)
        {
            this.conflictService = conflictService;
            this.conflictInvolvementService = conflictInvolvementService;
            this.conflictRecordService = conflictRecordService;
        }
        public async Task<int> CreateAsync(ConflictCreateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var id = await conflictService.CreateAsync(entityDto);
                await uow.CommitAsync();
                return id;
            }
        }

        public async Task<ConflictGetDTO> GetAsync(int id, bool include = true)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await conflictService.GetAsync(id, include);
            }
        }

        public async Task<bool> UpdateAsync(ConflictUpdateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await conflictService.GetAsync(entityDto.Id, false)) == null)
                {
                    return false;
                }

                await conflictService.UpdateAsync(entityDto);
                await uow.CommitAsync();
                return true;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await conflictService.GetAsync(id, false)) == null)
                {
                    return false;
                }
                await conflictService.DeleteAsync(id);
                await uow.CommitAsync();
                return true;
            }
        }

        private async Task<int> AddConflictInvolvementAsync(ConflictInvolvementCreateDTO entityDto, IUnitOfWork uow)
        {
            var id = await conflictInvolvementService.CreateAsync(entityDto);
            await uow.CommitAsync();
            return id;
        }

        public async Task<int> AddConflictInvolvementAsync(ConflictInvolvementCreateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await AddConflictInvolvementAsync(entityDto, uow);
            }
        }

        public Task<bool> DeleteConflictInvolvementAsync(int id)
        {
            return DeleteAsync(id, conflictInvolvementService.DeleteAsync, conflictInvolvementService.GetAsync);
        }

        private async Task<int> AddConflictRecordAsync(ConflictRecordCreateDTO entityDto, IUnitOfWork uow)
        {
            var id = await conflictRecordService.CreateAsync(entityDto);
            await uow.CommitAsync();
            return id;
        }

        public async Task<int> AddConflictRecordAsync(int clientId, int conflictId, ConflictRecordCreateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var involvement = await conflictInvolvementService.GetAsync(clientId, conflictId);
                if (involvement == null)
                {
                    var involvementCreate = new ConflictInvolvementCreateDTO();
                    involvementCreate.ClientId = clientId;
                    involvementCreate.ConflictId = conflictId;
                    entityDto.ConflictInvolvementId = await AddConflictInvolvementAsync(involvementCreate, uow);
                }
                else
                {
                    entityDto.ConflictInvolvementId = involvement.Id;
                }
                return await AddConflictRecordAsync(entityDto, uow);
            }
        }

        public async Task<int> AddConflictRecordAsync(ConflictRecordCreateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await conflictInvolvementService.GetAsync(entityDto.ConflictInvolvementId, false)) == null)
                {
                    return -1;
                }
                return await AddConflictRecordAsync(entityDto, uow);
            }
        }

        public async Task<bool> UpdateConflictRecordAsync(ConflictRecordUpdateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await conflictRecordService.GetAsync(entityDto.Id, false)) == null)
                {
                    return false; // not in database
                }
                await conflictRecordService.UpdateAsync(entityDto);
                await uow.CommitAsync();
            }
            return true;
        }

        public Task<bool> DeleteConflictRecordAsync(int id)
        {
            return DeleteAsync(id, conflictRecordService.DeleteAsync, conflictRecordService.GetAsync);
        }

        public async Task<IEnumerable<ConflictGetDTO>> GetAllConflictsAsync(
            int? directorId = null, bool active = true, bool sort = true, QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await conflictService.GetAllConflictsAsync(directorId, active, sort, queryPagingDto))
                    .Dtos;
            }
        }

        public async Task<IEnumerable<ClientGetDTO>> GetAllConflictParticipantsAsync(int conflictId)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var conflict = await conflictService.GetAsync(conflictId);
                return conflict?.Participants ?? null;
            }
        }

        public async Task<IEnumerable<ConflictRecordGetDTO>> GetAllConflictRecords(int conflictId)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var conflict = await conflictService.GetAsync(conflictId);
                return conflict?.ConflictRecords ?? null;
            }
        }

        public async Task<IEnumerable<ConflictRecordGetDTO>> GetAllRecordsWithParticipantIdSorted(int id,
            QueryPagingDTO? queryPagingDto = null)
        {
            using (var uwo = unitOfWorkProvider.Create())
            {
                return (await conflictRecordService.GetAllRecordsWithParticipantIdSorted(id, queryPagingDto)).Dtos;
            }
        }

        public async Task<IEnumerable<ConflictInvolvementGetDTO>> GetAllInvolvementsByClientAsync(int clientId,
            QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await conflictInvolvementService.GetAllInvolvementsByClientAsync(
                    clientId, queryPagingDto)).Dtos;
            }
        }

        public async Task<IEnumerable<ConflictInvolvementGetDTO>> GetAllConflictInvolvementsAsync(
            QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await conflictInvolvementService.GetAllConflictInvolvementsAsync(queryPagingDto)).Dtos;
            }
        }
        
        // used to delete a generic entity tied to conflict
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