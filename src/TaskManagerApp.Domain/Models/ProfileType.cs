namespace TaskManagerApp.Domain.Models
{
    public class ProfileType : Entity
    {
        public ProfileType()
        {
            Profiles = new();
        }

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<Profile> Profiles { get; set; }
    }
}