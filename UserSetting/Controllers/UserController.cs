using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserSetting.Data;
using UserSetting.Models;
using UserSetting.Repositories;

namespace UserSetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChange();
            return Ok(user);
        }
    }
}
