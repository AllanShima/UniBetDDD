using UniBet.Contexts.Profile.Entities;

namespace UniBet.Contexts.Profile.Interfaces.IRepositories
{
    public interface IAchievementRepository
    {
        public Achievement GetById(Guid id);
    }
}
