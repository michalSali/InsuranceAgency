using System;

namespace BLL.DTOs.People.User
{
    /// <summary>
    /// DTO that represents flag of user roles
    /// </summary>
    [Flags]
    public enum UserRoleDTO
    {
        None = 0,
        Administrator = 1 << 0,
        Director = 1 << 1,
        Client = 1 << 2,
        InsuranceAgent = 1 << 3,
    }
}