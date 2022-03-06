using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.People.InsuranceAgent
{
    /// <summary>
    /// DTO used to create insurance agent
    /// </summary>
    public class InsuranceAgentCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int DirectorId { get; set; }
    }
}