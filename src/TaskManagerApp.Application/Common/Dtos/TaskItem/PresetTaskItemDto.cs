namespace TaskManagerApp.Application.Common.Dtos.TaskItem
{
    public sealed class PresetTaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public short Importance { get; set; }
        public string? Comment { get; set; }
        public int UserId { get; set; }
    }
}
