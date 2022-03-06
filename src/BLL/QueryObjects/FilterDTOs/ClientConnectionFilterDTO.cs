using System.Linq;
using DAL.Models;

namespace BLL.QueryObjects.FilterDTOs
{
    public class ClientConnectionFilterDTO : QueryFilterDTO<ClientConnection>
    {
        public ClientConnectionFilterDTO() {}
        
        public ClientConnectionFilterDTO(int clientId)
        {
            Filter.Add(queryable => queryable.Where(
                conn => conn.ObjectId == clientId || conn.SubjectId == clientId));
        }
    }
}