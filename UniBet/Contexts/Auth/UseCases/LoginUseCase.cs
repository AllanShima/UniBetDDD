using UniBet.Contexts.Auth.Entities;
using UniBet.Contexts.Auth.ValueObjects;
using UniBet.Contexts.Auth.Repositories;

namespace UniBet.Contexts.Auth.UseCases
{
    public class LoginUseCase
    {
        private readonly IUserRepository _userRepository;
        public LoginUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public string Run(string email, string password)
        {
            User user = this._userRepository.Login(new Email(email), new Password(password));

            if (user == null)
            {
                throw new Exception("Email ou senha inválido...");
            }

            return user.Login();
        }
    }
}
