namespace TaskManagerApp.Application.Dtos
{
    public class Login
    {
        public string Password { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}