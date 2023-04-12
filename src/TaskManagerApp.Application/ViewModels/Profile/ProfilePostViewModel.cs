using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.ViewModels.Profile
{
    public sealed class ProfilePostViewModel
    {
        public ProfilePostViewModel()
        {
            PresetTaskItems = new();
        }

        public string Name { get; set; } = string.Empty;
        public short? HoursTarget { get; set; }
        public short? TasksTarget { get; set; }
        public int UserId { get; set; }
        public int ProfileTypeId { get; set; }
        public List<PresetTaskItemPostViewModel> PresetTaskItems { get; set; }
    }
}