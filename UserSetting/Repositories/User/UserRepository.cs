using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using UserSetting.Data;
using UserSetting.Models;
using UserSetting.Repositories.UnitOfWork;

namespace UserSetting.Repositories.User
{
    public class UserRepository : Repository<UserApp>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserApp> GetUserNameAsync(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName || x.Email == userName);

            if (user == null)
                return null;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!isPasswordValid)
                return null;

            return user;
        }

        public async Task<UserApp> AddUserAsync(string userName, string email, string password)
        {
            UserApp user = new UserApp()
            {
                UserName = userName.Trim(),
                Email = email.Trim(),
                Password = BCrypt.Net.BCrypt.HashPassword(password).Trim()
            };

            await _context.Users.AddAsync(user);

            await _unitOfWork.SaveAsync();

            return user;
        }
    }
}
