using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories;
using UniBet.Contexts.Billing.DTOs.Requests.UserRequests;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Interfaces.IRepositories;

namespace UniBet.Contexts.Billing.Interfaces.UseCases.UserCases
{
    public sealed class UpdateUserProfileUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserProfileUseCase(IUserRepository repository)
        {
            this._userRepository = repository;
        }

        public async void Run(UpdateUserProfileRequest cmd)
        {
            try
            {
                User user = this._userRepository.GetById(cmd.UserId);
                if (user == null)
                {
                    throw new Exception("Invalid User");
                }
                user.ChangeProfile(cmd.Name, cmd.Name, new Email(cmd.Email), cmd.BirthDate);
                this._userRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o perfil: " + ex.Message);
            }
        }
    }
}
