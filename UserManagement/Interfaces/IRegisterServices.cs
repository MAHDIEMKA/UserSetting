using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Applicaton.DTOs;
using UserManagement.Domain.Entities;

namespace UserManagement.Applicaton.Interfaces
{
    public interface IRegisterServices
    {
        Task<User> RegisterAsync(RegisterDTO registerDTO);
    }
}
