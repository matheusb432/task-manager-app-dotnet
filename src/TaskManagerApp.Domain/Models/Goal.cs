namespace TaskManagerApp.Domain.Models
{
    public sealed class Goal : Entity
    {
        public Goal()
        {
            GoalSteps = new();
            GoalTaskItems = new();
        }

        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public List<GoalStep> GoalSteps { get; set; }
        public List<GoalTaskItem> GoalTaskItems { get; set; }
    }
}