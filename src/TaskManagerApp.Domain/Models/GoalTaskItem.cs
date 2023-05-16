namespace TaskManagerApp.Domain.Models
{
    public sealed class GoalTaskItem : Entity
    {
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public Goal? Goal { get; set; }
        public TaskItem? TaskItem { get; set; }
    }
}
