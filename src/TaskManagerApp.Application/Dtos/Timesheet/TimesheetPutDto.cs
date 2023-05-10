using TaskManagerApp.Application.Dtos.TaskItem;

namespace TaskManagerApp.Application.Dtos.Timesheet
{
    public sealed class TimesheetPutDto
    {
        public TimesheetPutDto()
        {
            Notes = new();
            Tasks = new();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Finished { get; set; }
        public List<TimesheetNotePutDto> Notes { get; set; }
        public List<TaskItemPutDto> Tasks { get; set; }
    }
}