using TaskManagerApp.Application.Dtos.TaskItem;

namespace TaskManagerApp.Application.Dtos.Timesheet
{
    public sealed class TimesheetPostDto
    {
        public TimesheetPostDto()
        {
            TimesheetNotes = new();
            TaskItems = new();
        }

        public DateTime Date { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNotePostDto> TimesheetNotes { get; set; }
        public List<TaskItemPostDto> TaskItems { get; set; }
    }
}