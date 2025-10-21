
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserNameAsync(string userName);

        Task<User> AddUserAsync(User user);
    }
}
