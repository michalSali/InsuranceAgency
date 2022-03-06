using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.People.Client
{
    /// <summary>
    /// DTO used to update client
    /// </summary>
    public class ClientUpdateDTO : DTOBase
    {
        [Required]
        public int InsuranceAgentId { get; set; }
    }
}