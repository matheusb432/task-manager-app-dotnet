namespace TaskManagerApp.Domain.Models
{
    public class Timesheet : Entity
    {
        public Timesheet()
        {
            TimesheetNotes = new();
            TaskItems = new();
        }

        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<TimesheetNote> TimesheetNotes { get; set; }
        public List<TaskItem> TaskItems { get; set; }
    }
}