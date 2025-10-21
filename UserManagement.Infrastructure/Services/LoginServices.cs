using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Applicaton.DTOs;
using UserManagement.Applicaton.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Infrastructure.Services
{
    public class LoginServices: ILoginServices
    {
        private readonly IUserRepository _repo;

        public LoginServices(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<User> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _repo.GetUserNameAsync(loginDTO.UserName, loginDTO.Password);

            return user;
        }
    }
}
