using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories;
using UniBet.Contexts.Billing.DTOs.Requests;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Interfaces.IRepositories;
using UniBet.Repositories;

namespace UniBet.Contexts.Billing.UseCases.GameCases
{
    public class PlaceGameUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;
        public PlaceGameUseCase(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;

        }
        public void Run(PlaceGameRequest request)
        {
            try
            {
                User user = _userRepository.GetById(request.UserId);

                if (user == null) {
                    throw new Exception("User Inválido");
                }

                Game game = _gameRepository.GetById(request.GameId);

                if (game == null) {
                    throw new Exception("Game Inválido");
                }

                user.Withdraw(new Amount(request.Amount));

                game.Place(request.UserId, new Amount(request.Amount), new Team(request.Team));

                _userRepository.Update(user);
                _gameRepository.Update(game);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception(ex.Message);
            }
        }
    }
}
