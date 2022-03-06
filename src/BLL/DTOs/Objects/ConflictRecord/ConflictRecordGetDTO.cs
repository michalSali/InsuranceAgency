using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.People.Client;
using System;

namespace BLL.DTOs.Objects.ConflictRecord
{
    /// <summary>
    /// DTO used to get conflict record
    /// </summary>
    public class ConflictRecordGetDTO : DTOBase
    {
        public DateTime Date { get; set; }

        public int BalanceChange { get; set; }

        public string Description { get; set; }

        public ClientGetDTO Paricipant { get; set; }

        public ConflictGetDTO Conflict { get; set; }
    }
}