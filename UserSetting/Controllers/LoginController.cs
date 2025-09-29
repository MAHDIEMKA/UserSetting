using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserSetting.Data;
using UserSetting.Models;
using UserSetting.Repositories;
using UserSetting.Repositories.UnitOfWork;

namespace UserSetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string email, string password)
        {
            var existingUser = await _unitOfWork.Users.GetUserNameAsync(username);
            if(existingUser != null)
            {
                return BadRequest("Username is exists");
            }

            var user = new UserApp
            {
                UserName = username,
                Email = email,
                Password = password
            };
            //var user = _mapper.Map<UserApp>(registerDto);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return Ok(new {message = "User registered"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _unitOfWork.Users.LoginAsync(username, password);

            if(user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new {message = "Login successful", user = user.UserName});
        }
    }
}
