using TaskManagerApp.Application.ViewModels.User;

namespace TaskManagerApp.Application.Dtos
{
    public class AuthResponse
    {
        public AuthResponse(UserAuthGet user, string token)
        {
            User = user;
            Token = token;
        }

        public UserAuthGet User { get; }
        public string Token { get; }
    }
}