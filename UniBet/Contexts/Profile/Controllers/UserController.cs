using Microsoft.AspNetCore.Mvc;
using UniBet.Contexts.Profile.DTO;
using UniBet.Contexts.Profile.Entities;
using UniBet.Contexts.Profile.UseCases;

namespace UniBet.Contexts.Profile.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly GetUserDataUseCase _getUserDataUseCase;
        private readonly UpdateMainDataUseCase _updateMainDataUseCase;
        private readonly CreateOptionalDataUseCase _createOptionalDataUseCase;
        private readonly UpdateOptionalDataUseCase _updateOptionalDataUseCase;
        private readonly AddAchievementUseCase _addAchievementUseCase;
        private readonly ListAchievementUseCase _listAchievementUseCase;
        private readonly ListNotificationsUseCase _listNotificationsUseCase;

        public UserController(
            GetUserDataUseCase getUserDataUseCase,
            UpdateMainDataUseCase updateMainDataUseCase,
            CreateOptionalDataUseCase createOptionalDataUseCase,
            UpdateOptionalDataUseCase updateOptionalDataUseCase,
            AddAchievementUseCase addAchievementUseCase,
            ListAchievementUseCase listAchievementUseCase,
            ListNotificationsUseCase listNotificationsUseCase)
        {
            this._getUserDataUseCase = getUserDataUseCase;
            this._updateMainDataUseCase = updateMainDataUseCase;
            this._createOptionalDataUseCase = createOptionalDataUseCase;
            this._updateOptionalDataUseCase = updateOptionalDataUseCase;
            this._addAchievementUseCase = addAchievementUseCase;
            _listAchievementUseCase = listAchievementUseCase;
            _listNotificationsUseCase = listNotificationsUseCase;
        }

        [HttpGet("GetUserData")]
        public IActionResult GetUserData([FromBody] Guid userId)
        {
            _getUserDataUseCase.Run(userId);
            return Ok("Dados do usuário obtidos com sucesso!");
        }
        [HttpGet("GetUserData")]
        public IActionResult UpdateMainData([FromBody] string Name, string email, string password)
        {
            try
            {
                _updateMainDataUseCase.Run(Name, email, password);
                return Ok("Dados principais atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateOptionalData")]
        public IActionResult CreateOptionalData([FromBody]CreateOptionalDataDTO userDTO)
        {
            try
            {
                _createOptionalDataUseCase.Run(userDTO);
                return Created(userDTO);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("UpdateOptionalData")]
        public IActionResult UpdateOptionalData([FromBody] string phone)
        {
            try
            {
                _updateOptionalDataUseCase.Run(phone);
                return Ok(phone);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("AddAchievement")]
        public IActionResult AddAchievement([FromBody] Guid userId, Guid achievementId)
        {
            try
            {
                _addAchievementUseCase.Run(userId, achievementId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ListNotifications")]
        public IActionResult ListNotifications()
        {
            try
            {
                List<Notification> list = _listNotificationsUseCase.Run();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ListAchievements")]
        public IActionResult ListAchievements()
        {
            try {
                List<Achievement> list = _listAchievementUseCase.Run();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
