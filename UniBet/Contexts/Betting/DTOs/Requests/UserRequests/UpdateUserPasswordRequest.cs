namespace UniBet.Contexts.Billing.DTOs.Requests.UserRequests
{
    public class UpdateUserPasswordRequest
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
    }
}
