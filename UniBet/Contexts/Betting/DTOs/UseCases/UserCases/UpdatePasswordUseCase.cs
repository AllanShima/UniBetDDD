using UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories;
using UniBet.Contexts.Billing.DTOs.Requests.UserRequests;
using UniBet.Contexts.Billing.Interfaces.IRepositories;

namespace UniBet.Contexts.Billing.DTOs.UseCases.UserCases
{
    public class UpdatePasswordUseCase
    {
        private readonly IUserRepository _users;

        public UpdatePasswordUseCase(IUserRepository users)
        {
            this._users = users;
        }

        public async void Run(UpdateUserPasswordRequest cmd)
        {
            if (string.IsNullOrEmpty(cmd.Password))
            {
                throw new Exception("A senha não pode ser vazia.");
            }
            if (cmd.Password.Length < 8)
            {
                throw new Exception("A senha deve conter pelo menos 8 caracteres.");
            }
            
            try
            {
                var user = this._users.GetById(cmd.UserId);
                user.UpdatePassword(new Password(cmd.Password));
                this._users.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o perfil: " + ex.Message);
            }
        }
    }
}
