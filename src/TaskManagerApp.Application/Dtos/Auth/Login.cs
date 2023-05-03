namespace TaskManagerApp.Application.Dtos.Auth
{
    public sealed class Login
    {
        public string Password { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}