using TaskManagerApp.Domain.Utils;

namespace TaskManagerApp.Application.Dtos.Profile
{
    public sealed class ProfileTypePostDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = ProfileTypes.Custom;
        public DateTime DateRangeStart { get; set; }
        public DateTime DateRangeEnd { get; set; }
    }
}