namespace TaskManagerApp.Domain.Models
{
    public sealed class Profile : Entity
    {
        public Profile()
        {
            ProfilePresetTaskItems = new();
        }

        public string Name { get; set; } = string.Empty;
        public short? TimeTarget { get; set; }
        public short? TasksTarget { get; set; }
        public short Priority { get; set; }
        public int UserId { get; set; }
        public int ProfileTypeId { get; set; }
        public User? User { get; set; }
        public ProfileType? ProfileType { get; set; }
        public List<ProfilePresetTaskItem> ProfilePresetTaskItems { get; set; }
    }
}