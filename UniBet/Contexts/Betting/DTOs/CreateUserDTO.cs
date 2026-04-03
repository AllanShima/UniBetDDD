using System.ComponentModel.DataAnnotations;

namespace UniBet.Contexts.Billing.DTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
