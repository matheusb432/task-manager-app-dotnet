using TaskManagerApp.Application.Dtos.TaskItem;

namespace TaskManagerApp.Application.Dtos.Timesheet
{
    public sealed class TimesheetDto
    {
        public TimesheetDto()
        {
            TimesheetNotes = new();
            TaskItems = new();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNoteDto> TimesheetNotes { get; set; }
        public List<TaskItemDto> TaskItems { get; set; }
    }
}