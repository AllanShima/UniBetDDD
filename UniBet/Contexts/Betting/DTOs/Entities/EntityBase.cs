namespace UniBet.Contexts.Billing.DTOs.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime? RemovedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public EntityBase() 
        {
            Id = Guid.NewGuid();
        }
    }
}
