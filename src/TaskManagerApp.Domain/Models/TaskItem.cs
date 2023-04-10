namespace TaskManagerApp.Domain.Models
{
    public sealed class TaskItem : Entity
    {
        public TaskItem()
        {
            TaskItemNotes = new();
            GoalTaskItems = new();
        }

        public string Title { get; set; }
        public short Hours { get; set; }
        public int TimesheetId { get; set; }
        public Timesheet? Timesheet { get; set; }
        public List<TaskItemNote> TaskItemNotes { get; set; }
        public List<GoalTaskItem> GoalTaskItems { get; set; }
    }
}