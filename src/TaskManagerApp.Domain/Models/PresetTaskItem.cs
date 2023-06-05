namespace TaskManagerApp.Domain.Models
{
    public sealed class PresetTaskItem : Entity
    {
        public PresetTaskItem()
        {
            ProfilePresetTaskItems = new();
            TaskItems = new();
        }

        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public short Importance { get; set; }
        public string? Comment { get; set; }

        public List<TaskItem> TaskItems { get; set; }
        public List<ProfilePresetTaskItem> ProfilePresetTaskItems { get; set; }
    }
}
