namespace TaskManagerApp.Domain.Models
{
    public class TimesheetNote : Entity
    {
        public string Comment { get; set; } = string.Empty;
        public int TimesheetId { get; set; }
        public Timesheet? Timesheet { get; set; }
    }
}