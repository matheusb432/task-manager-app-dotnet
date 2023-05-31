using AutoMapper;
using System.Net;
using TaskManagerApp.Application.Common.Dtos.User;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;
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
        private readonly IPasswordService _passwordService;

        public UserService(
            IUserRepository repo,
            IRoleRepository roleRepo,
            IPasswordService passwordService,
            IMapper mapper
        ) : base(mapper, repo)
        {
            _roleRepo = roleRepo;
            _passwordService = passwordService;
        }

        public OperationResult RolesQuery() =>
            Success(Mapper.ProjectTo<RoleDto>(_roleRepo.Query()));

        public override async Task<OperationResult> Insert(UserPostDto dto)
        {
            var newUser = Mapper.Map<User>(dto);
            newUser.PasswordHash = _passwordService.HashPassword(newUser, dto.Password);
            if (newUser == null || !EntityIsValid(new UserValidator(), newUser))
                return Error(HttpStatusCode.BadRequest);

            if (await _repo.EmailExists(newUser.Email))
                return Error($"Email {newUser.Email} is already in use", HttpStatusCode.Conflict);

            if (await _repo.UserNameExists(newUser.UserName))
            {
                return Error(
                    $"User name {newUser.UserName} is already in use",
                    HttpStatusCode.Conflict
                );
            }

            await _repo.InsertAsync(newUser);
            return Success(newUser.Id);
        }
    }
}
