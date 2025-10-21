
using Microsoft.AspNetCore.Mvc;
using UserManagement.Applicaton.DTOs;
using UserManagement.Applicaton.Interfaces;
using UserManagement.Domain.Entities;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        
        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = await _loginServices.LoginAsync(loginDTO);

                return Ok(new { message = "ورود موفقیت آمیز (:", user = user.UserName });
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
