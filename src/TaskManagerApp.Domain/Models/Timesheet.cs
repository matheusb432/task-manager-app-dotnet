namespace TaskManagerApp.Domain.Models
{
    public sealed class Timesheet : Entity
    {
        public Timesheet()
        {
            Notes = new();
            Tasks = new();
        }

        public DateTime Date { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNote> Notes { get; set; }
        public List<TaskItem> Tasks { get; set; }
    }
}
