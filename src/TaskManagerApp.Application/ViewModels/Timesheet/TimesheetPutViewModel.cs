using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.ViewModels.Timesheet
{
    public sealed class TimesheetPutViewModel
    {
        public TimesheetPutViewModel()
        {
            TimesheetNotes = new();
            TaskItems = new();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNotePutViewModel> TimesheetNotes { get; set; }
        public List<TaskItemPutViewModel> TaskItems { get; set; }
    }
}