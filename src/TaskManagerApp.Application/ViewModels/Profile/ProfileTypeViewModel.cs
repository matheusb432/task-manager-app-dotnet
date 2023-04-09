namespace TaskManagerApp.Application.ViewModels.Profile
{
    public class ProfileTypeViewModel
    {
        public ProfileTypeViewModel()
        {
            Profiles = new();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime? DateRangeStart { get; set; }
        public DateTime? DateRangeEnd { get; set; }
        public List<ProfileViewModel> Profiles { get; set; }
    }
}