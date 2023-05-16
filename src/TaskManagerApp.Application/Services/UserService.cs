using AutoMapper;
using TaskManagerApp.Application.Dtos.User;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    internal sealed class UserService
        : EntityService<User, UserDto, UserPostDto, UserPutDto, UserValidator, IUserRepository>,
            IUserService
    {
        public UserService(IUserRepository repo, IMapper mapper) : base(mapper, repo) { }
    }
}
