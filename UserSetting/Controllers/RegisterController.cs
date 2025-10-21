using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Applicaton.DTOs;
using UserManagement.Applicaton.Interfaces;

namespace UserManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterServices _registerServices;

        public RegisterController(IRegisterServices registerServices)
        {
            _registerServices = registerServices;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                await _registerServices.RegisterAsync(registerDTO);

                return Ok(new { message = "ثبت نام شما با موفقیت انجام شد :)" });

            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }
    }
}
