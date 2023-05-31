using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Net;
using TaskManagerApp.Application.Common.Dtos.Auth;
using TaskManagerApp.Application.Profiles;
using TaskManagerApp.Application.Services;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Tests.Unit.Services
{
    public sealed class AuthServiceTests
    {
        private readonly AuthService _service;

        private readonly IMapper _mapper;

        private readonly Mock<IUserRepository> _userRepo;
        private readonly Mock<IPasswordService> _passwordService;

        private readonly List<User> _users;

        public AuthServiceTests()
        {
            _userRepo = new();
            _passwordService = new();

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new UserProfiles()));

            _mapper = mappingConfig.CreateMapper();

            _users = GetUsers();

            SetupMocks();

            _service = new AuthService(_userRepo.Object, _mapper, _passwordService.Object);
        }

        [Fact]
        public async Task Login_WithValidEmail_ShouldReturnSuccess()
        {
            var login = new Login { Email = _users[0].Email, Password = _users[0].PasswordHash, };

            var result = await _service.Login(login);
            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsAssignableFrom<AuthResponse>(result.Content);
        }

        [Fact]
        public async Task Login_WithValidUserName_ShouldReturnUser()
        {
            var login = new Login
            {
                UserName = _users[0].UserName,
                Password = _users[0].PasswordHash,
            };

            var result = await _service.Login(login);
            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsAssignableFrom<AuthResponse>(result.Content);
        }

        [Fact]
        public async Task Login_WithInvalidLogin_ShouldReturnUnathorized()
        {
            var login = new Login { Password = _users[0].PasswordHash, };

            var result = await _service.Login(login);
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, -1)]
        [InlineData(-1, 3)]
        public async Task Login_WithInvalidCredentials_ShouldReturnUnathorized(
            int emailIndex,
            int passwordIndex
        )
        {
            var email = _users.ElementAtOrDefault(emailIndex)?.Email ?? "fake@email.com";
            var password = _users.ElementAtOrDefault(passwordIndex)?.PasswordHash ?? "fakepassword";
            var login = new Login { Email = email, Password = password, };

            var result = await _service.Login(login);
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        [Fact]
        public async Task Signup_WithValidSignup_ShouldReturnCreatedUser()
        {
            var signup = new Signup
            {
                Email = "created_user@example.com",
                Password = "password",
                UserName = "created123",
                Name = "Created User",
            };

            var result = await _service.Signup(signup);
            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsAssignableFrom<AuthResponse>(result.Content);
        }

        [Fact]
        public async Task Signup_WithExistingUser_ShouldReturnConflict()
        {
            var user = _users[0];
            var signup = new Signup
            {
                Email = user.Email,
                Password = user.PasswordHash,
                Name = user.Name,
                UserName = user.UserName,
            };

            var result = await _service.Signup(signup);
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
        }

        [Fact]
        public async Task Signup_WithInvalidSignup_ShouldReturnUnauthorized()
        {
            var signup = new Signup { Password = "pass123", Name = "user name", };

            var result = await _service.Signup(signup);
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        private void SetupMocks()
        {
            _userRepo
                .Setup(x => x.InsertAsync(It.IsAny<User>(), It.IsAny<bool>()))
                .ReturnsAsync(
                    (User user, bool _) =>
                    {
                        _users.Add(user);
                        return user;
                    }
                );
            _userRepo
                .Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((string email) => _users.Find((x) => x.Email == email));
            _userRepo
                .Setup(x => x.GetByUserNameAsync(It.IsAny<string>()))
                .ReturnsAsync((string userName) => _users.Find((x) => x.UserName == userName));
            _userRepo
                .Setup(x => x.EmailExists(It.IsAny<string>()))
                .ReturnsAsync((string email) => _users.Any((x) => x.Email == email));
            _userRepo
                .Setup(x => x.UserNameExists(It.IsAny<string>()))
                .ReturnsAsync((string userName) => _users.Any((x) => x.UserName == userName));

            _passwordService
                .Setup(x => x.SignupToUserWithHashedPassword(It.IsAny<Signup>()))
                .Returns((Signup signup) => new User { PasswordHash = signup.Password + "-hash" });
            _passwordService
                .Setup(x => x.IsCorrectPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns((User user, string pass) => user.PasswordHash == pass);
        }

        public static List<User> GetUsers() =>
            new()
            {
                new User
                {
                    Name = "Alice",
                    UserName = "alice123",
                    Email = "alice@example.com",
                    PasswordHash = "password1",
                },
                new User
                {
                    Name = "Bob",
                    UserName = "bob456",
                    Email = "bob@example.com",
                    PasswordHash = "password2",
                },
                new User
                {
                    Name = "Charlie",
                    UserName = "charlie789",
                    Email = "charlie@example.com",
                    PasswordHash = "password3",
                },
                new User
                {
                    Name = "Dave",
                    UserName = "dave012",
                    Email = "dave@example.com",
                    PasswordHash = "password4",
                },
                new User
                {
                    Name = "Eve",
                    UserName = "eve345",
                    Email = "eve@example.com",
                    PasswordHash = "password5",
                },
                new User
                {
                    Name = "Frank",
                    UserName = "frank678",
                    Email = "frank@example.com",
                    PasswordHash = "password6",
                },
            };
    }
}
