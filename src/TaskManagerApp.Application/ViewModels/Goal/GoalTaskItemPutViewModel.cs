using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.ViewModels.Goal
{
    public class GoalTaskItemPutViewModel
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public TaskItemPutViewModel? TaskItem { get; set; }
    }
}