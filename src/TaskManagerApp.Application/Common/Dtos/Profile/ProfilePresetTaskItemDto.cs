using TaskManagerApp.Application.Common.Dtos.TaskItem;

namespace TaskManagerApp.Application.Common.Dtos.Profile
{
    public sealed class ProfilePresetTaskItemDto
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int PresetTaskItemId { get; set; }
        public PresetTaskItemDto? PresetTaskItem { get; set; }
    }
}
