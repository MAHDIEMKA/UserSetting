using UserSetting.Repositories.User;

namespace UserSetting.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        Task<int> SaveAsync();
    }
}
