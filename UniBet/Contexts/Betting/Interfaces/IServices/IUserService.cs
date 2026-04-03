using UniBet.Contexts.Billing.DTOs;
using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Filters;
using UniBet.Contexts.Billing.DTOs.Helpers;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Helpers;

namespace UniBet.Contexts.Billing.Interfaces.IServices
{
    public interface IUserService
    {
        public List<User> ListUsers();
        public User GetById(Guid id);
        public Paginator<UserEmail> Paginate(UserFilter filter);
        public void CreateUser(CreateUserDTO user);
        public void UpdateUser(Guid Id, User user);
        public void DeleteUser(Guid id);
    }
}
