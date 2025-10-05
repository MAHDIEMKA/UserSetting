using UserSetting.Models;
using UserSetting.Repositories.UnitOfWork;
using UserSetting.Repositories.User;

namespace UserSetting.Services.Login
{
    public class LoginServices : ILoginServices
    {

        private readonly IUserRepository _repo;

        public LoginServices(IUserRepository repository)
        {
            _repo = repository;
        }

        public async Task<UserApp> LoginAsync(string userName, string password)
        {
            var user = await _repo.GetUserNameAsync(userName, password);

            return user;
        }
    }
}
