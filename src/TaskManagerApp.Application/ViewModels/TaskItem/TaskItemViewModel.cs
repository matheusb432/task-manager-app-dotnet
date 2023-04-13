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
        public short? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public int TimesheetId { get; set; }
        public List<TaskItemNoteViewModel> TaskItemNotes { get; set; }
    }
}