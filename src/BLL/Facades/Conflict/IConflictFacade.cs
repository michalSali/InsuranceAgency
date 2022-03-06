using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.Objects.ConflictInvolvement;
using BLL.DTOs.Objects.ConflictRecord;
using BLL.DTOs.People.Client;
using BLL.QueryObjects;

namespace BLL.Facades.Conflict
{
    public interface IConflictFacade
    {
        Task<int> CreateAsync(ConflictCreateDTO entityDto);

        Task<ConflictGetDTO> GetAsync(int id, bool include=true);
        
        Task<bool> UpdateAsync(ConflictUpdateDTO entityDto);

        Task<bool> DeleteAsync(int id);

        Task<int> AddConflictInvolvementAsync(ConflictInvolvementCreateDTO entityDto);
        
        Task<bool> DeleteConflictInvolvementAsync(int id);

        Task<int> AddConflictRecordAsync(int clientId, int conflictId, ConflictRecordCreateDTO entityDto);

        Task<int> AddConflictRecordAsync(ConflictRecordCreateDTO entityDto);

        Task<bool> UpdateConflictRecordAsync(ConflictRecordUpdateDTO entityDto);

        Task<bool> DeleteConflictRecordAsync(int id);

        Task<IEnumerable<ConflictGetDTO>> GetAllConflictsAsync(int? directorId=null,
            bool active = true, bool sort = true, QueryPagingDTO? queryPagingDto = null);

        Task<IEnumerable<ClientGetDTO>> GetAllConflictParticipantsAsync(int conflictId);

        Task<IEnumerable<ConflictRecordGetDTO>> GetAllConflictRecords(int conflictId);

        Task<IEnumerable<ConflictRecordGetDTO>> GetAllRecordsWithParticipantIdSorted(int id,
            QueryPagingDTO? queryPagingDto = null);

        Task<IEnumerable<ConflictInvolvementGetDTO>> GetAllInvolvementsByClientAsync(int clientId,
            QueryPagingDTO? queryPagingDto = null);

        Task<IEnumerable<ConflictInvolvementGetDTO>> GetAllConflictInvolvementsAsync(
            QueryPagingDTO? queryPagingDto = null);
    }
}