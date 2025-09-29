using Microsoft.EntityFrameworkCore;
using UserSetting.Data;
using UserSetting.Models;

namespace UserSetting.Repositories.User
{
    public class UserRepository : Repository<UserApp>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserApp> GetUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName || x.Email == userName);
        }

        public async Task<UserApp> LoginAsync(string userName, string password)
        {
            var user = await GetUserNameAsync(userName);
            if(user == null)
            {
                return null;
            }
            return user;
        }
    }
}
