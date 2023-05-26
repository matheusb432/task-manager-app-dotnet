using TaskManagerApp.Application.Common.Dtos.User;

namespace TaskManagerApp.Application.Common.Dtos.Auth
{
    public sealed class AuthResponse
    {
        public AuthResponse(UserAuthDto user, string token)
        {
            User = user;
            Token = token;
        }

        public UserAuthDto User { get; }
        public string Token { get; }
    }
}
