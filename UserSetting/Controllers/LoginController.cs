
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
            var user = await _loginServices.LoginAsync(loginDTO);

            if (user == null)
            {
                return Unauthorized(new { message = "کاربری با این مشخصات وجود ندارد" });
            }

            return Ok(new { message = "ورود موفقیت آمیز (:", user = user.UserName });
        }
    }
}
