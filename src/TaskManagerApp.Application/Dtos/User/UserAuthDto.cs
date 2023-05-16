namespace TaskManagerApp.Application.Dtos.User
{
    public sealed class UserAuthDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
