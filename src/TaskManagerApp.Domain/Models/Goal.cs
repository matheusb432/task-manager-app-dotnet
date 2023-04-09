namespace TaskManagerApp.Domain.Models
{
    public class Goal : Entity
    {
        public Goal()
        {
            GoalSteps = new();
            GoalTaskItems = new();
        }

        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<GoalStep> GoalSteps { get; set; }
        public List<GoalTaskItem> GoalTaskItems { get; set; }
    }
}