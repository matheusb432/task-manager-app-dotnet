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
        public string TimeTarget { get; set; } = string.Empty;
        public short? TasksTarget { get; set; }
        public short Priority { get; set; }
        public int UserId { get; set; }
        public int ProfileTypeId { get; set; }
        public ProfileTypeViewModel? ProfileType { get; set; }
        public List<ProfilePresetTaskItemViewModel> ProfilePresetTaskItems { get; set; }
    }
}