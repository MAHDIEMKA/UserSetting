using UserSetting.Models;

namespace UserSetting.Repositories.User
{
    public interface IUserRepository : IRepository<UserApp>
    {
        Task<UserApp> GetUserNameAsync(string userName);
        Task<UserApp> LoginAsync(string userName, string password);
    }
}
