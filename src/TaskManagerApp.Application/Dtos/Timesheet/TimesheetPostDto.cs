using TaskManagerApp.Application.Dtos.TaskItem;

namespace TaskManagerApp.Application.Dtos.Timesheet
{
    public sealed class TimesheetPostDto
    {
        public TimesheetPostDto()
        {
            Notes = new();
            Tasks = new();
        }

        public DateTime Date { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNotePostDto> Notes { get; set; }
        public List<TaskItemPostDto> Tasks { get; set; }
    }
}