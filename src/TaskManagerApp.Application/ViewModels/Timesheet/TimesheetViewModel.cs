using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.ViewModels.Timesheet
{
    public class TimesheetViewModel
    {
        public TimesheetViewModel()
        {
            TimesheetNotes = new();
            TaskItems = new();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNoteViewModel> TimesheetNotes { get; set; }
        public List<TaskItemViewModel> TaskItems { get; set; }
    }
}