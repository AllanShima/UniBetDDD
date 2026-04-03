using UniBet.Contexts.Billing.DTOs.Interfaces;

namespace UniBet.Contexts.Billing.DTOs.Requests.UserRequests
{
    public class UpdateUserProfileRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
