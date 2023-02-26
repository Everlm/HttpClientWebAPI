namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public int id { get; set; }
        public DateTime creationAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
