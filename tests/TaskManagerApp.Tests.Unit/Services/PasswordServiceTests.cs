using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using TaskManagerApp.Application.Profiles;
using TaskManagerApp.Application.Services;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Tests.Unit.Services
{
    public class PasswordServiceTests
    {
        private readonly PasswordService _service;

        private readonly IMapper _mapper;

        private readonly Mock<IPasswordHasher<User>> _passwordHasher;

        public PasswordServiceTests()
        {
            _passwordHasher = new();

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new UserProfiles()));

            _mapper = mappingConfig.CreateMapper();

            SetupMocks();

            _service = new PasswordService(_mapper, _passwordHasher.Object);
        }

        private void SetupMocks()
        {
            _passwordHasher
                .Setup(x => x.HashPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns((User _, string pass) => pass + "-hash");
            _passwordHasher
                .Setup(
                    x =>
                        x.VerifyHashedPassword(
                            It.IsAny<User>(),
                            It.IsAny<string>(),
                            It.IsAny<string>()
                        )
                )
                .Returns(
                    (User user, string _, string pass) =>
                        user.PasswordHash == pass
                            ? PasswordVerificationResult.Success
                            : PasswordVerificationResult.Failed
                );
        }
    }
}
