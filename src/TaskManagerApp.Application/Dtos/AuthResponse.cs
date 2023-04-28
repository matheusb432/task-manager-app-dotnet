using TaskManagerApp.Application.ViewModels.User;

namespace TaskManagerApp.Application.Dtos
{
    public class AuthResponse
    {
        public AuthResponse(UserViewModel user, string token)
        {
            User = user;
            Token = token;
        }

        public UserViewModel User { get; }
        public string Token { get; }
    }
}