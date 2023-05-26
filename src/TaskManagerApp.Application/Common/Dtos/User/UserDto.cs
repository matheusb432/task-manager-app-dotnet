using TaskManagerApp.Application.Common.Dtos.Profile;
using TaskManagerApp.Application.Common.Dtos.TaskItem;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Common.Dtos.User
{
    public sealed class UserDto
    {
        public UserDto()
        {
            Profiles = new();
            PresetTaskItems = new();
            UserRoles = new();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<ProfileDto> Profiles { get; set; }
        public List<PresetTaskItemDto> PresetTaskItems { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
