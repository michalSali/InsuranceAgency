using BLL.DTOs.Objects.ConflictRecord;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.Director;
using System;
using System.Collections.Generic;

namespace BLL.DTOs.Objects.Conflict
{
    /// <summary>
    /// DTO used to get conflict
    /// </summary>
    public class ConflictGetDTO : DTOBase
    {
        public string Location { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Beginning { get; set; }

        public DateTime? End { get; set; }

        public DirectorGetDTO Director { get; set; }

        public virtual ICollection<ConflictRecordGetDTO> ConflictRecords { get; set; }

        public virtual ICollection<ClientGetDTO> Participants { get; set; }
    }
}