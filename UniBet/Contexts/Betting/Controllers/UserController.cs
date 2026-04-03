using Microsoft.AspNetCore.Mvc;
using UniBet.Contexts.Billing.DTOs;
using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Filters;
using UniBet.Contexts.Billing.DTOs.Interfaces.IServices;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Interfaces.IServices;
using static System.Net.WebRequestMethods;

namespace UniBet.Contexts.Billing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            this._service = service;
        }

        [HttpGet("ListUsers")]
        public IActionResult ListUsers()
        {
            List<User> list = this._service.ListUsers();
            return Ok(list);
        }

        [HttpPost("Paginate")]
        public IActionResult Paginate([FromBody] UserFilter filter)
        {
            try
            {
                this._service.Paginate(filter);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserDTO user)
        {
            try
            {
                this._service.CreateUser(user);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] Guid Id)
        {
            try
            {
                User user = this._service.GetById(Id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
