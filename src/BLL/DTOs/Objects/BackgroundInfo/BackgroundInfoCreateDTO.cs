using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Objects.BackgroundInfo
{
    /// <summary>
    /// DTO used to create background info
    /// </summary>
    public class BackgroundInfoCreateDTO
    {
        [Required]
        public int ClientId { get; set; }

        [StringLength(200)]
        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}