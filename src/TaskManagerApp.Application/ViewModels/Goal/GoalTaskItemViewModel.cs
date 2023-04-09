using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.ViewModels.Goal
{
    public class GoalTaskItemViewModel
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public TaskItemViewModel? TaskItem { get; set; }
    }
}