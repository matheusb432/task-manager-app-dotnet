namespace TaskManagerApp.Domain.Models
{
    // TODO refactor to use composite keys
    public sealed class ProfilePresetTaskItem : Entity
    {
        public int ProfileId { get; set; }
        public int PresetTaskItemId { get; set; }
        public Profile? Profile { get; set; }
        public PresetTaskItem? PresetTaskItem { get; set; }
    }
}
