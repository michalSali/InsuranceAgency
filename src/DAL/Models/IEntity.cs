namespace DAL.Models
{
    /// <summary>
    /// Interface for needed attributes as an entity in database
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}