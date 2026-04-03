using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Filters;
using UniBet.Contexts.Billing.DTOs.Helpers;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Helpers;

namespace UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public Paginator<User> PaginateAll(UserFilter filter);
        public User GetById(Guid Id);
        public void Create(User user);
        public void Update(User user);
        public void Delete(User user);
    }
}
