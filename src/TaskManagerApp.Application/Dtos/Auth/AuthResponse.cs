using TaskManagerApp.Application.Dtos.User;

namespace TaskManagerApp.Application.Dtos.Auth
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
