namespace TaskManagerApp.Application.ViewModels.Profile
{
    public sealed class ProfileViewModel
    {
        public ProfileViewModel()
        {
            ProfilePresetTaskItems = new();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public short? HoursTarget { get; set; }
        public short? TasksTarget { get; set; }
        public int UserId { get; set; }
        public int ProfileTypeId { get; set; }
        public ProfileTypeViewModel? ProfileType { get; set; }
        public List<ProfilePresetTaskItemViewModel> ProfilePresetTaskItems { get; set; }
    }
}