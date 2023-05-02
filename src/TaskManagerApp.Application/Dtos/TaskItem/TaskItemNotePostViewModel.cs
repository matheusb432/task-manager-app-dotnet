namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class TaskItemNotePostDto
    {
        public string Comment { get; set; } = string.Empty;
        public int TaskItemId { get; set; }
    }
}