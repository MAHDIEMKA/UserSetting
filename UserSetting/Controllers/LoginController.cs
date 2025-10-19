
using Microsoft.AspNetCore.Mvc;
using UserManagement.Applicaton.Interfaces;
using UserManagement.Domain.Entities;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        private readonly IRegisterServices _registerServices;
        

        public LoginController(ILoginServices loginServices, IRegisterServices registerServices)
        {
            _loginServices = loginServices;
            _registerServices = registerServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string user, string email, string password)
        {

            await _registerServices.RegisterAsync(user, email, password);

            return Ok(new { message = "ثبت نام شما با موفقیت انجام شد :)" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User userApp)
        {
            var user = await _loginServices.LoginAsync(userApp.UserName, userApp.PasswordHash);
            
            if(user == null)
            {
                return Unauthorized(new {message = "کاربری با این مشخصات وجود ندارد" });
            }

            return Ok(new {message = "ورود موفقیت آمیز (:", user = user.UserName});
        }
    }
}
