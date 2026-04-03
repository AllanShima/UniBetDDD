using Microsoft.AspNetCore.Mvc;
using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Interfaces.UseCases.GameCases;
using UniBet.Contexts.Billing.DTOs.Requests;
using UniBet.Contexts.Billing.DTOs.UseCases.GameCases;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Interfaces.UseCases.GameCases;
using UniBet.Contexts.Billing.UseCases.GameCases;
using UniBet.DTOs;
using UniBet.DTOs.Filters;
using UniBet.Interfaces.IServices;
using static System.Net.WebRequestMethods;

namespace UniBet.Contexts.Billing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly PlaceGameUseCase _placeGameUseCase;
        private readonly ListGamesUseCase _listGamesUseCase;
        private readonly GameActiveUseCase _gameActiveUseCase;
        private readonly GameCanceledUseCase _gameCanceledUseCase;
        public GameController(
            PlaceGameUseCase placeGameUserCase,
            ListGamesUseCase listGamesUseCase,
            GameActiveUseCase gameActiveUseCase,
            GameCanceledUseCase gameCanceledUseCase)
        {
            this._placeGameUseCase = placeGameUserCase;
            this._listGamesUseCase = listGamesUseCase;
            this._gameActiveUseCase = gameActiveUseCase;
            this._gameCanceledUseCase = gameCanceledUseCase;
        }

        public IActionResult Place(PlaceGameRequest request)
        {
            try
            {
                _placeGameUseCase.Run(request);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult ListAll()
        {
            try
            {
                List<Game> games = _listGamesUseCase.Run();
                return Ok(games);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult GameActive(Guid GameId)
        {
            try
            {
                _gameActiveUseCase.Run(GameId);

                // Listar o jogo atualizado
                Game game = _listGamesUseCase.Run().FirstOrDefault(g => g.Id == GameId);
                return Ok(game);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult GameCanceled(Guid GameId)
        {
            try
            {
                _gameCanceledUseCase.Run(GameId);

                // Listar o jogo atualizado
                Game game = _listGamesUseCase.Run().FirstOrDefault(g => g.Id == GameId);
                return Ok(game);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
