using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Interfaces.IRepositories;

namespace UniBet.Contexts.Billing.DTOs.Interfaces.UseCases.GameCases
{
    public class ListGamesUseCase
    {
        private readonly IGameRepository _gameRepository;
        public ListGamesUseCase(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public List<Game> Run()
        {
           // Lógica para listar os jogos
           List<Game> games = new List<Game>();
           games = _gameRepository.GetAll();
           return games;
        }
    }
}
