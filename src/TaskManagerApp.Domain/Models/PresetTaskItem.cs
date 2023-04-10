namespace TaskManagerApp.Domain.Models
{
    public sealed class PresetTaskItem : Entity
    {
        public PresetTaskItem()
        {
            ProfilePresetTaskItems = new();
        }

        public string Title { get; set; } = string.Empty;
        public short? Hours { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<ProfilePresetTaskItem> ProfilePresetTaskItems { get; set; }
    }
}