
using Microsoft.EntityFrameworkCore;
using UserManagement.Applicaton.DTOs;
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
            var user = await _context.Users.FirstOrDefaultAsync(x => (x.UserName == userName || x.Email == userName));

            if (user == null)
                return null;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!isPasswordValid)
                return null;

            return user;
        }

        public async Task<User> AddUserAsync(User userApp)
        {
            User user = new User()
            {
                UserName = userApp.UserName.Trim(),
                Email = userApp.Email.Trim(),
                PasswordHash = userApp.PasswordHash.Trim()
            };

            await _context.Users.AddAsync(user);


            return user;
        }

    }
}
