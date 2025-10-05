using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserSetting.Data;
using UserSetting.Models;
using UserSetting.Repositories;
using UserSetting.Repositories.UnitOfWork;
using UserSetting.Services.Login;

namespace UserSetting.Controllers
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

        //[HttpPost("register")]
        //public async Task<IActionResult> Register(string username, string email, string password)
        //{
        //    var existingUser = await _unitOfWork.Users.GetUserNameAsync(username, password);
        //    if(existingUser != null)
        //    {
        //        return BadRequest("Username is exists");
        //    }

        //    var user = new UserApp
        //    {
        //        UserName = username,
        //        Email = email,
        //        Password = password
        //    };
        //    //var user = _mapper.Map<UserApp>(registerDto);

        //    await _unitOfWork.Users.AddAsync(user);
        //    await _unitOfWork.SaveAsync();

        //    return Ok(new {message = "User registered"});
        //}

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserApp userApp)
        {
            var user = await _loginServices.LoginAsync(userApp.UserName, userApp.Password);
            
            if(user == null)
            {
                return Unauthorized(new {message = "Invalid username or password" });
            }

            return Ok(new {message = "Login seccesful", user = user.UserName});
        }
    }
}
