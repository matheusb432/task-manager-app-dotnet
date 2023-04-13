namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public sealed class TaskItemPostViewModel
    {
        public TaskItemPostViewModel()
        {
            TaskItemNotes = new();
        }

        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public int TimesheetId { get; set; }
        public List<TaskItemNotePostViewModel> TaskItemNotes { get; set; }
    }
}