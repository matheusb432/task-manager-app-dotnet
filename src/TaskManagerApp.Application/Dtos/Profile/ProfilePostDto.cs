using TaskManagerApp.Application.Dtos.TaskItem;

namespace TaskManagerApp.Application.Dtos.Profile
{
    public sealed class ProfilePostDto
    {
        public ProfilePostDto()
        {
            PresetTaskItems = new();
        }

        public string Name { get; set; } = string.Empty;
        public string TimeTarget { get; set; } = string.Empty;
        public short? TasksTarget { get; set; }
        public short? Priority { get; set; }
        public int ProfileTypeId { get; set; }
        public List<PresetTaskItemPostDto> PresetTaskItems { get; set; }
    }
}
