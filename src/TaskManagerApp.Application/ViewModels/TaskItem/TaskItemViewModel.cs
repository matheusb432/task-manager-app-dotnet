namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public sealed class TaskItemViewModel
    {
        public TaskItemViewModel()
        {
            TaskItemNotes = new();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public short Hours { get; set; }
        public int TimesheetId { get; set; }
        public List<TaskItemNoteViewModel> TaskItemNotes { get; set; }
    }
}