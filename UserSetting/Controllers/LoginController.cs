using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserSetting.Data;
using UserSetting.Models;
using UserSetting.Repositories;
using UserSetting.Repositories.UnitOfWork;
using UserSetting.Services.Login;
using UserSetting.Services.Register;

namespace UserSetting.Controllers
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
        public async Task<IActionResult> Register([FromBody] UserApp user)
        {

            await _registerServices.RegisterAsync(user.UserName, user.Email, user.Password);

            return Ok(new { message = "ثبت نام شما با موفقیت انجام شد :)" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserApp userApp)
        {
            var user = await _loginServices.LoginAsync(userApp.UserName, userApp.Password);
            
            if(user == null)
            {
                return Unauthorized(new {message = "کاربری با این مشخصات وجود ندارد" });
            }

            return Ok(new {message = "ورود موفقیت آمیز (:", user = user.UserName});
        }
    }
}
