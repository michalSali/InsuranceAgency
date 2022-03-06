using BLL.DTOs.Enums;
using BLL.DTOs.People.Client;

namespace BLL.DTOs.Objects.Gear
{
    /// <summary>
    /// DTO used to get gear
    /// </summary>
    public class GearGetDTO : DTOBase
    {
        public string Name;

        public GearType Type { get; set; }

        public int Value { get; set; }

        public int ClientId { get; set; }

        public ClientGetDTO Client { get; set; }
    }
}