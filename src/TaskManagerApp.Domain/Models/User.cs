namespace TaskManagerApp.Domain.Models
{
    public sealed class User : Entity
    {
        public User()
        {
            Timesheets = new();
            Profiles = new();
            PresetTaskItems = new();
        }

        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public List<Timesheet> Timesheets { get; set; }
        public List<Profile> Profiles { get; set; }
        public List<PresetTaskItem> PresetTaskItems { get; set; }
    }
}