using UniBet.Contexts.Profile.Entities;
using UniBet.Contexts.Profile.Interfaces.IRepositories;


namespace UniBet.Contexts.Profile.UseCases
{
    public class ListAchievementUseCase
    {
        private readonly IUserRepository _userRepository;

        public ListAchievementUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<Achievement> Run(Guid userId)
        {
            User user = this._userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            List<Achievement> achievements = user.ListAchievements();

            return achievements;
        }
    }
}
