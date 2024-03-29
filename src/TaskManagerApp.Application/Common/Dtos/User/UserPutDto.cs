﻿namespace TaskManagerApp.Application.Common.Dtos.User
{
    public sealed class UserPutDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordReset { get; set; } = string.Empty;
        public List<UserRolePutDto> UserRoles { get; set; } = new();
    }
}
