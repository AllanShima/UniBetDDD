using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Interfaces.IRepositories;

namespace UniBet.Contexts.Billing.UseCases.GameCases
{
    public class GameCanceledUseCase
    {
        private readonly IGameRepository _gameRepository;

        public GameCanceledUseCase(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void Run(Guid GameId)
        {
            Game game = _gameRepository.GetById(GameId);
            if (game == null)
            {
                throw new Exception("Game Inválido");
            }

            game.StatusCanceled();
            _gameRepository.Update(game);
        }
    }
}
