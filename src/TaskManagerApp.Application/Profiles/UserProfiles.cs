﻿using TaskManagerApp.Application.ViewModels.User;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class UserProfiles : AutoMapper.Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserPostViewModel, User>();
            CreateMap<UserPutViewModel, User>();
        }
    }
}