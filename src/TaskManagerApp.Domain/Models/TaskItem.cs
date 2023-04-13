namespace TaskManagerApp.Domain.Models
{
    public sealed class TaskItem : Entity
    {
        public TaskItem()
        {
            TaskItemNotes = new();
            GoalTaskItems = new();
        }

        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public int TimesheetId { get; set; }
        public Timesheet? Timesheet { get; set; }
        public List<TaskItemNote> TaskItemNotes { get; set; }
        public List<GoalTaskItem> GoalTaskItems { get; set; }
    }
}