using TaskManagerApp.Application.Common.Dtos.TaskItem;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Common.Dtos.Profile
{
    public sealed class ProfilePostDto
    {
        public ProfilePostDto()
        {
            PresetTaskItems = new();
            ProfilePresetTaskItems = new();
        }

        public string Name { get; set; } = string.Empty;
        public string TimeTarget { get; set; } = string.Empty;
        public short? TasksTarget { get; set; }
        public short? Priority { get; set; }
        public int ProfileTypeId { get; set; }
        public List<PresetTaskItemPostDto> PresetTaskItems { get; set; }
        public List<ProfilePresetTaskItemPostDto> ProfilePresetTaskItems { get; set; }
    }
}
