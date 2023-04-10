namespace TaskManagerApp.Application.ViewModels.Timesheet
{
    public sealed class TimesheetNotePostViewModel
    {
        public string Comment { get; set; } = string.Empty;
        public int TimesheetId { get; set; }
    }
}