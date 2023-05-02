using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TaskManagerApp.Application.Configurations;
using TaskManagerApp.Application.Dtos.Auth;
using TaskManagerApp.Application.Dtos.User;
using TaskManagerApp.Application.Dtos.Validators;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public sealed class AuthService : Service, IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IUserRepository userRepo, IMapper mapper, IPasswordHasher<User> passwordHasher)
            : base(mapper)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> Login(Login login)
        {
            var authenticatedUser = await Authenticate(login);

            if (authenticatedUser == null)
                return Error(HttpStatusCode.Unauthorized);

            var token = AuthConfig.CreateToken(authenticatedUser);

            return Success(BuildResponse(authenticatedUser, token));
        }

        public async Task<OperationResult> Signup(Signup signup)
        {
            var newUser = SignupToUserWithHashedPassword(signup);
            if (newUser == null || !EntityIsValid(new UserValidator(), newUser))
                return Error(HttpStatusCode.Unauthorized);

            if (await _userRepo.EmailExists(newUser.Email))
                return Error($"Email {newUser.Email} is already in use", HttpStatusCode.Conflict);

            if (await _userRepo.UserNameExists(newUser.UserName))
                return Error($"User name {newUser.UserName} is already in use", HttpStatusCode.Conflict);

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

            var user = string.IsNullOrEmpty(userName) ? await _userRepo.GetByEmailAsync(email) : await _userRepo.GetByUserNameAsync(userName);

            return IsCorrectPassword(user, login.Password) ? user : null;
        }

        public User? SignupToUserWithHashedPassword(Signup signup)
        {
            if (!IsValid(new SignupValidator(), signup))
                return null;

            var user = Mapper.Map<User>(signup);
            user.PasswordHash = _passwordHasher.HashPassword(user, signup.Password);
            return user;
        }

        private AuthResponse BuildResponse(User user, string token)
            => new(Mapper.Map<UserAuthDto>(user), token);

        private bool IsCorrectPassword(User? user, string password)
        {
            if (string.IsNullOrEmpty(user?.PasswordHash)) return false;

            return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success;
        }
    }
}