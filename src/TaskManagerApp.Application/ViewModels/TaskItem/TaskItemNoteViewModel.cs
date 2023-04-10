namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public sealed class TaskItemNoteViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int TaskItemId { get; set; }
    }
}