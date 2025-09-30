using UserSetting.Models;

namespace UserSetting.Repositories.User
{
    public interface IUserRepository : IRepository<UserApp>
    {
        Task<UserApp> GetUserNameAsync(string userName, string password);
        Task<UserApp> LoginAsync(string userName, string password);
    }
}
