using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.BackgroundInfo
{
    /// <summary>
    /// DTO used to update background info
    /// </summary>
    public class BackgroundInfoUpdateDTO : DTOBase
    {
        [Required]
        public int ClientId { get; set; }

        [StringLength(200)]
        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}