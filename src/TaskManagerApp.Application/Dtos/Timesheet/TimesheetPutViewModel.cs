using TaskManagerApp.Application.Dtos.TaskItem;

namespace TaskManagerApp.Application.Dtos.Timesheet
{
    public sealed class TimesheetPutDto
    {
        public TimesheetPutDto()
        {
            TimesheetNotes = new();
            TaskItems = new();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNotePutDto> TimesheetNotes { get; set; }
        public List<TaskItemPutDto> TaskItems { get; set; }
    }
}