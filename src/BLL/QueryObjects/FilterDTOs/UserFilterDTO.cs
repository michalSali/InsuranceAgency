using DAL.Models;
using System.Linq;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// Filter DTO used to filter user data in queries
    /// </summary>
    public class UserFilterDTO : QueryFilterDTO<User>
    {
        /// <summary>
        /// Consturcts filter DTO that filters users based on given name
        /// </summary>
        /// <param name="name"> string name to filter on </param>
        public UserFilterDTO(string name)
        {
            Filter.Add(queryable => queryable.Where(user => user.Name == name));
        }
    }
}