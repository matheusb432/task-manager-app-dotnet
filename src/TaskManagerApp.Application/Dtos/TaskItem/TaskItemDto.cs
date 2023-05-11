namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public string? Comment { get; set; }
        public int TimesheetId { get; set; }
    }
}