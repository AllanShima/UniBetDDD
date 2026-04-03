namespace UniBet.Contexts.Profile.Entities
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Desctiption { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
