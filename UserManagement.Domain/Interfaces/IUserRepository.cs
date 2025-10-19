using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserNameAsync(string userName, string password);

        Task<User> AddUserAsync(string userName, string email, string password);
    }
}
