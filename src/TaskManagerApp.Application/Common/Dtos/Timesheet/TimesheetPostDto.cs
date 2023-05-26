using TaskManagerApp.Application.Common.Dtos.TaskItem;

namespace TaskManagerApp.Application.Common.Dtos.Timesheet
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
