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
            return await _context.Users.FirstOrDefaultAsync(x => (x.UserName == userName || x.Email == userName) && x.Password == password);
        }

        public async Task<UserApp> AddUserAsync(string userName, string email, string password)
        {
            UserApp user = new UserApp()
            {
                UserName = userName,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _context.Users.AddAsync(user);

            _unitOfWork.SaveAsync();

            return user;
        }
    }
}
