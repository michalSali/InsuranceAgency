namespace BLL.DTOs.People.User
{
    /// <summary>
    /// DTO that is used for user login
    /// </summary>
    public class UserLoginDTO
    {
        public string Name { get; set; }
        
        public string Password { get; set; }
    }
}