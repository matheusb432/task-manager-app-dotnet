using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TaskManagerApp.Application.Common.Dtos.Auth;
using TaskManagerApp.Application.Common.Dtos.Validators;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Services
{
    public interface IPasswordService
    {
        User? SignupToUserWithHashedPassword(Signup signup);

        bool IsCorrectPassword(User? user, string password);

        string HashPassword(User user, string password);
    }

    public class PasswordService : Service, IPasswordService
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordService(IMapper mapper, IPasswordHasher<User> passwordHasher) : base(mapper)
        {
            _passwordHasher = passwordHasher;
        }

        public User? SignupToUserWithHashedPassword(Signup signup)
        {
            if (!IsValid(new SignupValidator(), signup))
                return null;

            var user = Mapper.Map<User>(signup);
            user.PasswordHash = HashPassword(user, signup.Password);
            return user;
        }

        public string HashPassword(User user, string password) =>
            _passwordHasher.HashPassword(user, password);

        public bool IsCorrectPassword(User? user, string password)
        {
            if (string.IsNullOrEmpty(user?.PasswordHash))
                return false;

            return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password)
                == PasswordVerificationResult.Success;
        }
    }
}
