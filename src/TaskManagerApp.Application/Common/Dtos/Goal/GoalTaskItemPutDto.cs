using TaskManagerApp.Application.Common.Dtos.TaskItem;

namespace TaskManagerApp.Application.Common.Dtos.Goal
{
    public sealed class GoalTaskItemPutDto
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public TaskItemPutDto? TaskItem { get; set; }
    }
}
