using UserSetting.Models;

namespace UserSetting.Services.Register
{
    public interface IRegisterServices
    {
        Task<UserApp> RegisterAsync(string userName, string email, string password);
    }
}
