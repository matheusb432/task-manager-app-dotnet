using TaskManagerApp.Application.Dtos.TaskItem;

namespace TaskManagerApp.Application.Dtos.Goal
{
    public sealed class GoalTaskItemPutDto
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public TaskItemPutDto? TaskItem { get; set; }
    }
}
