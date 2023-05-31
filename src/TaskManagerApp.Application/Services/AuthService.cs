using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TaskManagerApp.Application.Common.Dtos.Auth;
using TaskManagerApp.Application.Common.Dtos.User;
using TaskManagerApp.Application.Common.Dtos.Validators;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;
using TaskManagerApp.Application.Configurations;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public sealed class AuthService : Service, IAuthService
    {
        private readonly IUserRepository _userRepo;

        private readonly IPasswordService _passwordService;

        public AuthService(
            IUserRepository userRepo,
            IMapper mapper,
            IPasswordService passwordService
        ) : base(mapper)
        {
            _userRepo = userRepo;
            _passwordService = passwordService;
        }

        public async Task<OperationResult> Login(Login login)
        {
            var authenticatedUser = await Authenticate(login);

            if (authenticatedUser == null)
                return Error("Invalid login credentials!", HttpStatusCode.Unauthorized);

            var token = AuthConfig.CreateToken(authenticatedUser);

            return Success(BuildResponse(authenticatedUser, token));
        }

        public async Task<OperationResult> Signup(Signup signup)
        {
            var newUser = _passwordService.SignupToUserWithHashedPassword(signup);
            if (newUser == null || !EntityIsValid(new UserValidator(), newUser))
                return Error("Invalid signup data!", HttpStatusCode.Unauthorized);

            if (await _userRepo.EmailExists(newUser.Email))
                return Error($"Email {newUser.Email} is already in use", HttpStatusCode.Conflict);

            if (await _userRepo.UserNameExists(newUser.UserName))
            {
                return Error(
                    $"User name {newUser.UserName} is already in use",
                    HttpStatusCode.Conflict
                );
            }

            var createdUser = await _userRepo.InsertAsync(newUser);

            var token = AuthConfig.CreateToken(createdUser);

            return Success(BuildResponse(createdUser, token));
        }

        public async Task<User?> Authenticate(Login login)
        {
            if (!IsValid(new LoginValidator(), login))
                return null;

            var userName = login.UserName ?? "";
            var email = login.Email ?? "";

            var user = string.IsNullOrEmpty(userName)
                ? await _userRepo.GetByEmailAsync(email)
                : await _userRepo.GetByUserNameAsync(userName);

            return _passwordService.IsCorrectPassword(user, login.Password) ? user : null;
        }

        private AuthResponse BuildResponse(User user, string token) =>
            new(Mapper.Map<UserAuthDto>(user), token);
    }
}
