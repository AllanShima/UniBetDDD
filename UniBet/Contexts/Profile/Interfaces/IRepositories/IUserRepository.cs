using UniBet.Contexts.Profile.DTO;
using UniBet.Contexts.Profile.Entities;

namespace UniBet.Contexts.Profile.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public User GetById(Guid id);
        public void UpdateMainData(Guid userId, string document, string phone);
        public void CreateOptionalData(CreateOptionalDataDTO optionalDataDTO);
        public void UpdateOptionalData(string phone);
        public void AddAchievement(Guid userId, Achievement achievement);
        public List<Achievement> GetAchievementList(Guid userId);
        public List<Notification> GetNotifications(Guid userId); 
    }
}
