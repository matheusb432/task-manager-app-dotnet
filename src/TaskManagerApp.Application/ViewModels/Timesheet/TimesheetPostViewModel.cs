using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.ViewModels.Timesheet
{
    public class TimesheetPostViewModel
    {
        public TimesheetPostViewModel()
        {
            TimesheetNotes = new();
            TaskItems = new();
        }

        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNotePostViewModel> TimesheetNotes { get; set; }
        public List<TaskItemPostViewModel> TaskItems { get; set; }
    }
}