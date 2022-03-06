using BLL.DTOs.People.Client;

namespace BLL.DTOs.Objects.ClientConnection
{
    /// <summary>
    /// DTO used to get client connection
    /// </summary>
    public class ClientConnectionGetDTO : DTOBase
    {
        public string Description { get; set; }

        public virtual ClientGetDTO Object { get; set; }

        public virtual ClientGetDTO Subject { get; set; }
    }
}