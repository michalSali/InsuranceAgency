using DAL.Models;
using System.Linq;

namespace BLL.QueryObjects.FilterDTOs
{
    /// <summary>
    /// DTO used to filter client by id
    /// </summary>
    public class ClientFilterByIdDTO : QueryFilterDTO<Client>
    {
        public ClientFilterByIdDTO(int id)
        {
            Filter.Add(queryable => queryable.Where(client => client.Id == id));
        }
    }
}