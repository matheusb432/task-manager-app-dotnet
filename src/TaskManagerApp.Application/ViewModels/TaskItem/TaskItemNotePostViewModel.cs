namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public sealed class TaskItemNotePostViewModel
    {
        public string Comment { get; set; } = string.Empty;
        public int TaskItemId { get; set; }
    }
}