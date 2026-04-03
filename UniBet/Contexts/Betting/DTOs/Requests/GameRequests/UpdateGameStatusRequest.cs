namespace UniBet.Contexts.Billing.DTOs.Requests.GameRequests
{
    public class UpdateGameStatusRequest
    {
        public Guid GameId { get; set; }
        public string Status { get; set; }
    }
}
