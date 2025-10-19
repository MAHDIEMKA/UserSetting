using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Applicaton.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Infrastructure.Services
{
    public class RegisterServices: IRegisterServices
    {
        private readonly IUserRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterServices(IUserRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> RegisterAsync(string userName, string email, string password)
        {
            var existingUser = await _repo.GetUserNameAsync(userName, password);
            if (existingUser != null)
            {
                throw new Exception("کاربر با این مشخصات وجود دارد");
            }

            var user = await _repo.AddUserAsync(userName, email, password);
            
            await _unitOfWork.SaveAsync();

            return user;
        }
    }
}
