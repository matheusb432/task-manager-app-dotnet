namespace TaskManagerApp.Application.Dtos.Timesheet
{
    public sealed class TimesheetNotePostDto
    {
        public string Comment { get; set; } = string.Empty;
        public int TimesheetId { get; set; }
    }
}