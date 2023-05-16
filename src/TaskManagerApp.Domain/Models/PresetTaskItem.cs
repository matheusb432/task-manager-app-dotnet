namespace TaskManagerApp.Domain.Models
{
    public sealed class PresetTaskItem : Entity
    {
        public PresetTaskItem()
        {
            ProfilePresetTaskItems = new();
        }

        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public List<ProfilePresetTaskItem> ProfilePresetTaskItems { get; set; }
    }
}
