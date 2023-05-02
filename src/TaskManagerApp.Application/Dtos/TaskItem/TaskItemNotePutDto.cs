namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class TaskItemNotePutDto
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int TaskItemId { get; set; }
    }
}