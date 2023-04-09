namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public class TaskItemPutViewModel
    {
        public TaskItemPutViewModel()
        {
            TaskItemNotes = new();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public short Hours { get; set; }
        public int TimesheetId { get; set; }
        public List<TaskItemNotePutViewModel> TaskItemNotes { get; set; }
    }
}