using BLL.DTOs.People.User;

namespace BLL.DTOs.People.Administrator
{
    /// <summary>
    /// DTO used to get administrator
    /// </summary>
    public class AdministratorGetDTO : DTOBase
    {
        public UserInfoDTO User { get; set; }
    }
}