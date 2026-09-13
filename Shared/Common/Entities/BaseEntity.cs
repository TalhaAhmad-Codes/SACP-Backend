namespace Backend.Shared.Common.Entities
{
    // This class serves as a base entity for all entities in the application.
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = null;

        public void MarkUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
