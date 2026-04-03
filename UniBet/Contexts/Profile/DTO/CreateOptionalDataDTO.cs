namespace UniBet.Contexts.Profile.DTO
{
    public class CreateOptionalDataDTO
    {
        public Guid userId { get; private set; }
        public string document { get; private set; }
        public string phone { get; private set; }
    }
}
