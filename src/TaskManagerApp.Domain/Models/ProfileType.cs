namespace TaskManagerApp.Domain.Models
{
    public sealed class ProfileType : Entity
    {
        public ProfileType()
        {
            Profiles = new();
        }

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime? DateRangeStart { get; set; }
        public DateTime? DateRangeEnd { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}
