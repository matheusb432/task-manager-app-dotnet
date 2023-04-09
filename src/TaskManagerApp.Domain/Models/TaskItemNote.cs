namespace TaskManagerApp.Domain.Models
{
    public class TaskItemNote : Entity
    {
        public string Comment { get; set; } = string.Empty;
        public int TaskItemId { get; set; }
        public TaskItem? TaskItem { get; set; }
    }
}