using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TaskManagerApp.Application.Dtos;
using TaskManagerApp.Application.Dtos.Validators;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Application.ViewModels.User;
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

        // TODO - implement auth methods
        public async Task<OperationResult> Login(Login login)
        {
            var authenticatedUser = await Authenticate(login);

            if (authenticatedUser == null)
                return Error(HttpStatusCode.Unauthorized);

            var token = CreateJwtToken(authenticatedUser);

            return Success(new AuthResponse(Mapper.Map<UserViewModel>(authenticatedUser), token));
        }

        public async Task<OperationResult> Signup(Signup signup)
        {
            var newUser = SignupToUserWithHashedPassword(signup);
            if (newUser == null || !EntityIsValid(new UserValidator(), newUser))
                return Error(HttpStatusCode.Unauthorized);

            // TODO remove this error handling after testing, it's a security risk
            // TODO research if returning conflict is best practice in this instance
            if (await _userRepo.EmailExists(newUser.Email))
                return Error("Email already exists", HttpStatusCode.Conflict);

            if (await _userRepo.UserNameExists(newUser.UserName))
                return Error("UserName already exists", HttpStatusCode.Conflict);

            var createdUser = await _userRepo.InsertAsync(newUser);

            var token = CreateJwtToken(createdUser);

            return Success(new AuthResponse(Mapper.Map<UserViewModel>(createdUser), token));
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

        // TODO add proper typing
        private string CreateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // TODO add dynamic key
            //var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("Jwt:Secret"));
            var key = Encoding.ASCII.GetBytes("mock-key-mock-key-mock-key-mock-key-mock-key-mock-key-mock-key-mock-key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                }),
                // TODO test token expiration
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private bool IsCorrectPassword(User? user, string password)
        {
            if (string.IsNullOrEmpty(user?.PasswordHash)) return false;

            return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success;
        }
    }
}