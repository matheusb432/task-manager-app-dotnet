using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Application.Dtos.Auth;
using TaskManagerApp.Application.Interfaces;

namespace TaskManagerApp.API.Controllers
{
    [AllowAnonymous]
    public sealed class AuthController : Controller
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service) => _service = service;

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Post(Login data) =>
            CustomResponse(await _service.Login(data));

        [HttpPost("signup")]
        public async Task<ActionResult<AuthResponse>> Post(Signup data) =>
            CustomResponse(await _service.Signup(data));
    }
}
