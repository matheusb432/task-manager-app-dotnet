namespace TaskManagerApp.Application.Common.Dtos.Profile
{
    public sealed class ProfileTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime? DateRangeStart { get; set; }
        public DateTime? DateRangeEnd { get; set; }
    }
}
