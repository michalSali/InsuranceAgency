using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.ConflictRecord
{
    /// <summary>
    /// DTO used to create conflict record
    /// </summary>
    public class ConflictRecordCreateDTO
    {
        public DateTime Date { get; set; }

        public int BalanceChange { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public int ConflictInvolvementId { get; set; }
    }
}