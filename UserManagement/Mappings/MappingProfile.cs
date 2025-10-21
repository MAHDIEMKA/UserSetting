using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Applicaton.DTOs;
using UserManagement.Domain.Entities;

namespace UserManagement.Applicaton.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, User>().ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<User, LoginDTO>();
        }
    }
}
