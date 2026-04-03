using UniBet.Contexts.Profile.Entities;
using UniBet.Contexts.Profile.Interfaces.IRepositories;

namespace UniBet.Contexts.Profile.UseCases
{
    public class ListNotificationsUseCase
    {
        private readonly IUserRepository _userRepository;

        public ListNotificationsUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<Notification> Run(Guid userId)
        {
            User user = this._userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            List<Notification> notifications = user.ListNotifications();

            return notifications;
        }
    }
}
