using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Application.Dtos;
using TaskManagerApp.Application.Dtos.Validators;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Services
{
    internal sealed class AuthService : Service, IAuthService
    {
        private readonly IUserService _userService;
        public AuthService(IUserService userService, IMapper mapper)
            : base(mapper)
        {
            _userService = userService;
        }

        public async Task<OperationResult> Login(Login login)
        {
            if (!IsValid(new LoginValidator(), login))
                return Error(HttpStatusCode.BadRequest);

            throw new NotImplementedException();
        }

        public async Task<OperationResult> Signup(Signup signup)
        {
            if (!IsValid(new SignupValidator(), signup))
                return Error(HttpStatusCode.BadRequest);

            throw new NotImplementedException();
        }
    }
}
