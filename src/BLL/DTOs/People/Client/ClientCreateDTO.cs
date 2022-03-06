using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.People.Client
{
    /// <summary>
    /// DTO used to create client
    /// </summary>
    public class ClientCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int InsuranceAgentId { get; set; }
    }
}