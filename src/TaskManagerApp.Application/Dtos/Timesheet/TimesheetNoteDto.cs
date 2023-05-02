namespace TaskManagerApp.Application.Dtos.Timesheet
{
    public sealed class TimesheetNoteDto
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int TimesheetId { get; set; }
    }
}