namespace UniBet.Contexts.Billing.DTOs.Requests.GameRequests
{
    public class UpdateGameProfileRequest
    {
        public Guid GameId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
