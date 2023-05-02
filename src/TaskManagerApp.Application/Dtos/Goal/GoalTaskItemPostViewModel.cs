using TaskManagerApp.Application.Dtos.TaskItem;

namespace TaskManagerApp.Application.Dtos.Goal
{
    public sealed class GoalTaskItemPostDto
    {
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public TaskItemPostDto? TaskItem { get; set; }
    }
}