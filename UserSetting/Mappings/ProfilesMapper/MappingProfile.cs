using AutoMapper;
using UserSetting.Models;

namespace UserSetting.Mappings.ProfilesMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserApp, RegisterDto>().ReverseMap();
            //CreateMap<UserApp, LoginDto>().ReverseMap();
        }
    }
}
