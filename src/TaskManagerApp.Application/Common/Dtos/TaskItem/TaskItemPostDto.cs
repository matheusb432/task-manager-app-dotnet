namespace TaskManagerApp.Application.Common.Dtos.TaskItem
{
    public sealed class TaskItemPostDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public string? Comment { get; set; }
        public int TimesheetId { get; set; }
        public int? PresetTaskItemId { get; set; }
    }
}
