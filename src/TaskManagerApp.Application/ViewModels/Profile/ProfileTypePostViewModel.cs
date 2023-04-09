using TaskManagerApp.Domain.Utils;

namespace TaskManagerApp.Application.ViewModels.Profile
{
    public class ProfileTypePostViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = ProfileTypes.Custom;
        public DateTime DateRangeStart { get; set; }
        public DateTime DateRangeEnd { get; set; }
    }
}