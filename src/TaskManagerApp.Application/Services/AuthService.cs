using AutoMapper;
using System.Net;
using TaskManagerApp.Application.Dtos;
using TaskManagerApp.Application.Dtos.Validators;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public sealed class AuthService : Service, IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo, IMapper mapper)
            : base(mapper)
        {
            _userRepo = userRepo;
        }

        // TODO - implement auth methods
        public async Task<OperationResult> Login(Login login)
        {
            if (!IsValid(new LoginValidator(), login))
                return Error(HttpStatusCode.Unauthorized);

            throw new NotImplementedException();
        }

        public async Task<OperationResult> Signup(Signup signup)
        {
            if (!IsValid(new SignupValidator(), signup))
                return Error(HttpStatusCode.Unauthorized);

            throw new NotImplementedException();
        }
    }
}