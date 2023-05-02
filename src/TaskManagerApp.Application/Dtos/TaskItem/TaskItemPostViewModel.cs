namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class TaskItemPostDto
    {
        public TaskItemPostDto()
        {
            TaskItemNotes = new();
        }

        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public int TimesheetId { get; set; }
        public List<TaskItemNotePostDto> TaskItemNotes { get; set; }
    }
}