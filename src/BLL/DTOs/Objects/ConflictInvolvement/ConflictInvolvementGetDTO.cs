using BLL.DTOs.Objects.ConflictRecord;
using System.Collections.Generic;

namespace BLL.DTOs.Objects.ConflictInvolvement
{
    /// <summary>
    /// DTO used to get conflict involvement
    /// </summary>
    public class ConflictInvolvementGetDTO : DTOBase
    {
        public int ClientId { get; set; }

        public int ConflictId { get; set; }

        public ICollection<ConflictRecordGetDTO> ConflictRecords { get; set; }
    }
}