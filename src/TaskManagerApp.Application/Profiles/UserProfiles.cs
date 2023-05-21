using TaskManagerApp.Application.Dtos.Auth;
using TaskManagerApp.Application.Dtos.User;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class UserProfiles : AutoMapper.Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
            CreateMap<Signup, User>();
            CreateMap<User, UserAuthDto>();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
        }
    }
}
