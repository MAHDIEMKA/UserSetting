using UserSetting.Models;
using UserSetting.Repositories;
using UserSetting.Repositories.User;

namespace UserSetting.Services.Login
{
    public interface ILoginServices
    {
        Task<UserApp> LoginAsync(string userName, string password);
    }
}
