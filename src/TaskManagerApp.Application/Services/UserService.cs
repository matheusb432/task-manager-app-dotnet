using AutoMapper;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Application.ViewModels.User;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    internal sealed class UserService : EntityService<
        User,
        UserViewModel,
        UserPostViewModel,
        UserPutViewModel,
        UserValidator>, IUserService
    {
        public UserService(IUserRepository repo, IMapper mapper)
            : base(mapper, repo)
        {
        }
    }
}