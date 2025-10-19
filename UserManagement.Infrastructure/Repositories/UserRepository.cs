
using Microsoft.EntityFrameworkCore;
using UserManagement.Applicaton.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using UserManagement.Infrastructure.Persistence;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserNameAsync(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => (x.UserName == userName || x.PasswordHash == password));

            if (user == null)
                return null;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!isPasswordValid)
                return null;

            return user;
        }

        public async Task<User> AddUserAsync(string userName, string email, string password)
        {
            User user = new User()
            {
                UserName = userName.Trim(),
                Email = email.Trim(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password).Trim()
            };

            await _context.Users.AddAsync(user);


            return user;
        }

    }
}
