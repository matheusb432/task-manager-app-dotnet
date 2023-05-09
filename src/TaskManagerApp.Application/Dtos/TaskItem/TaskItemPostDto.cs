namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class TaskItemPostDto
    {
        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int TimesheetId { get; set; }
    }
}