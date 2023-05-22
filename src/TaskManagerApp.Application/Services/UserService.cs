using AutoMapper;
using TaskManagerApp.Application.Dtos.Profile;
using TaskManagerApp.Application.Dtos.User;
using TaskManagerApp.Application.Extensions;
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
        private readonly IRoleRepository _roleRepo;

        public UserService(IUserRepository repo, IRoleRepository roleRepo, IMapper mapper)
            : base(mapper, repo)
        {
            _roleRepo = roleRepo;
        }

        public OperationResult RolesQuery() =>
            Success(Mapper.ProjectTo<RoleDto>(_roleRepo.Query()));
    }
}
