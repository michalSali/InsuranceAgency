using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    /// <summary>
    /// Represents base entity with just the Id as key in database
    /// </summary>
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}