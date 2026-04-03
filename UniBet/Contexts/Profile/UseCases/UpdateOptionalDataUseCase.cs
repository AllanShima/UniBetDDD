using UniBet.Contexts.Profile.DTO;
using UniBet.Contexts.Profile.Entities;
using UniBet.Contexts.Profile.Interfaces.IRepositories;

namespace UniBet.Contexts.Profile.UseCases
{
    public class UpdateOptionalDataUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateOptionalDataUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public void Run(Guid userId, UpdateOptionalDataDTO data)
        {
            User user = this._userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            user.UpdateOptionalData(data);

            _userRepository.Update(user);
        }
    }
}
