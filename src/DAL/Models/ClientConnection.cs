using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents connection between two client entities in database
    /// </summary>
    public class ClientConnection : BaseEntity
    {
        public string Description { get; set; }

        public int ObjectId { get; set; }

        public int SubjectId { get; set; }

        [ForeignKey((nameof(ObjectId)))]
        public virtual Client Object { get; set; }

        [ForeignKey((nameof(SubjectId)))]
        public virtual Client Subject { get; set; }
    }
}