using AutoMapper;
using JwtAuth.Dtos;
using JwtAuth.Entities;

namespace JwtAuth.Utilities
{
    public class UserDtoEntity : Profile
    {
        public UserDtoEntity()
        {
            CreateMap<RegisterDto, UserDto>();
            CreateMap<UserDto, RegisterDto>();

            CreateMap<IdentityUser, UserDto>();
            CreateMap<UserDto, IdentityUser>();

            CreateMap<IdentityUser, JwtDto>().ForMember(x => x.Id, e=> e.MapFrom(o => o.Id.ToString()));
            CreateMap<JwtDto, IdentityUser>();
        }
    }
}