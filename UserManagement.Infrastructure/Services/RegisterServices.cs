using AutoMapper;
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
    public class RegisterServices: IRegisterServices
    {
        private readonly IUserRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterServices(IUserRepository repo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> RegisterAsync(RegisterDTO registerDTO)
        {
            var existingUser = await _repo.GetUserNameAsync(registerDTO.UserName);
            if (existingUser != null)
            {
                throw new Exception("کاربر با این مشخصات وجود دارد");
            }

            var user = _mapper.Map<User>(registerDTO);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);
            var addUser = await _repo.AddUserAsync(user);

            await _unitOfWork.SaveAsync();

            return user;
        }
    }
}
