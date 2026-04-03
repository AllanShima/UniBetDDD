namespace UniBet.Contexts.Billing.DTOs.Requests
{
    public class PlaceGameRequest
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public decimal Amount { get; set; }
        public string Team { get; set; }
    }
}
