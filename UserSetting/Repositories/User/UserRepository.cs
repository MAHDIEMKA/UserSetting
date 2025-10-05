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

        public async Task<UserApp> GetUserNameAsync(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => (x.UserName == userName || x.Email == userName) && x.Password == password);
        }

    }
}
