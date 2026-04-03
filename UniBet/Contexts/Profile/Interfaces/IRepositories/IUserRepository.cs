using UniBet.Contexts.Profile.DTO;
using UniBet.Contexts.Profile.Entities;

namespace UniBet.Contexts.Profile.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public User GetById(Guid id);
        public void Update(User user);
    }
}
