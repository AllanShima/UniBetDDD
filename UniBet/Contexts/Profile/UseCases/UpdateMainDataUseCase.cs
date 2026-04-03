using UniBet.Contexts.Profile.DTO;
using UniBet.Contexts.Profile.Entities;
using UniBet.Contexts.Profile.Interfaces.IRepositories;

namespace UniBet.Contexts.Profile.UseCases
{
    public class UpdateMainDataUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateMainDataUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public void Run(Guid userId, UpdateMainDataDTO data)
        {
            User user = this._userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            user.UpdateMainData(data);

            _userRepository.Update(user);
        }
    }
}
