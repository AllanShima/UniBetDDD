using UniBet.Contexts.Profile.Entities;
using UniBet.Contexts.Profile.Interfaces.IRepositories;

namespace UniBet.Contexts.Profile.UseCases
{
    public class GetUserDataUseCase
    {
        private readonly IUserRepository _userRepository;
        public GetUserDataUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public User Run(Guid userId)
        {
            User user = this._userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            return user;
        }
    }
}
