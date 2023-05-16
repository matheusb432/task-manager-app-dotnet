using TaskManagerApp.Domain.Utils;

namespace TaskManagerApp.Application.Dtos.Profile
{
    public sealed class ProfileTypePutDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = ProfileTypes.Custom;
        public DateTime DateRangeStart { get; set; }
        public DateTime DateRangeEnd { get; set; }
    }
}
