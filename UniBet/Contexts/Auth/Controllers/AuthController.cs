using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace UniBet.Contexts.Auth.Controllers
{
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }
         public IActionResult Login([FromBody] LoginRequest request)
         {
             try
             {
                 // código que faz login JWT e retorna token de autenticação
                 return Ok("nvjfjenjvfkjv k,vnrkfednj");
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }
         }
    }
}
