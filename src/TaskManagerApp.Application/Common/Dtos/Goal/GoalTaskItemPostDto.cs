using TaskManagerApp.Application.Common.Dtos.TaskItem;

namespace TaskManagerApp.Application.Common.Dtos.Goal
{
    public sealed class GoalTaskItemPostDto
    {
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public TaskItemPostDto? TaskItem { get; set; }
    }
}
