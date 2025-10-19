
using UserManagement.Applicaton.Interfaces;
using UserManagement.Domain.Interfaces;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Infrastructure.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public IUserRepository Users { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
