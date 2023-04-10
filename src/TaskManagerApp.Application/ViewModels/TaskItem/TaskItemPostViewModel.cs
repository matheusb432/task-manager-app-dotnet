namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public sealed class TaskItemPostViewModel
    {
        public TaskItemPostViewModel()
        {
            TaskItemNotes = new();
        }

        public string Title { get; set; } = string.Empty;
        public short Hours { get; set; }
        public int TimesheetId { get; set; }
        public List<TaskItemNotePostViewModel> TaskItemNotes { get; set; }
    }
}