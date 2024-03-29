﻿namespace TaskManagerApp.Application.Common.Dtos.User
{
    public sealed class UserPostDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<UserRolePostDto> UserRoles { get; set; } = new();
    }
}
