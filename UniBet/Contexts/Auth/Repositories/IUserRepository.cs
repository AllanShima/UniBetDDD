using UniBet.Contexts.Billing.DTOs.Interfaces;

namespace UniBet.Contexts.Auth.Repositories
{
    public class IUserRepository
    {
        public UserEmail Login(Email email, Password password);
    }
}
