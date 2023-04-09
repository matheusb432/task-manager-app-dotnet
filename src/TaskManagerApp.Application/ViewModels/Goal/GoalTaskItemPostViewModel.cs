using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.ViewModels.Goal
{
    public class GoalTaskItemPostViewModel
    {
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public TaskItemPostViewModel? TaskItem { get; set; }
    }
}