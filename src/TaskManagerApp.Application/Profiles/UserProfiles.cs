using TaskManagerApp.Application.Dtos;
using TaskManagerApp.Application.ViewModels.User;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class UserProfiles : AutoMapper.Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<UserPostViewModel, User>();
            CreateMap<UserPutViewModel, User>();
            CreateMap<Signup, User>();
            CreateMap<User, UserAuthGet>();
        }
    }
}