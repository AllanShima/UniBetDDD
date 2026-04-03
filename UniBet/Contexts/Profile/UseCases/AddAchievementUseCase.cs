using UniBet.Contexts.Profile.Entities;
using UniBet.Contexts.Profile.Interfaces.IRepositories;

namespace UniBet.Contexts.Profile.UseCases
{
    public class AddAchievementUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAchievementRepository _achievementRepository;
        public AddAchievementUseCase(IUserRepository userRepository, IAchievementRepository achievementRepository)
        {
            this._userRepository = userRepository;
            this._achievementRepository = achievementRepository;
        }
        public void Run(Guid userId, Guid achievementId)
        {
            User user = this._userRepository.GetById(userId);
            Achievement achievement = this._achievementRepository.GetById(achievementId);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            if (achievement == null)
            {
                throw new Exception("Conquista não encontrada");
            }

            user.AddAchievement(achievement);
        }
    }
}
