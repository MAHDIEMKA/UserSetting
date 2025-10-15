using UserSetting.Data;
using UserSetting.Models;
using UserSetting.Repositories;
using UserSetting.Repositories.User;

namespace UserSetting.Services.Register
{
    public class RegisterServices : IRegisterServices
    {
        private readonly IUserRepository _userRepository;

        public RegisterServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserApp> RegisterAsync(string userName, string email, string password)
        {
            var existingUser = _userRepository.GetUserNameAsync(userName,password);
            if(existingUser != null)
            {
                throw new Exception("کاربر با این مشخصات وجود دارد");
            }
            
            return await _userRepository.AddUserAsync(userName, email, password);
        }
    }
}
