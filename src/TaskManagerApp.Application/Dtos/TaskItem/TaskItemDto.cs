namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class TaskItemDto
    {
        public TaskItemDto()
        {
            TaskItemNotes = new();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public int TimesheetId { get; set; }
        public List<TaskItemNoteDto> TaskItemNotes { get; set; }
    }
}