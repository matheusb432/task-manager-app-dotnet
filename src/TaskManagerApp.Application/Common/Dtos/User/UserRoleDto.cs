namespace TaskManagerApp.Application.Common.Dtos.User
{
    public sealed class UserRoleDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public RoleDto? Role { get; set; }
    }
}
