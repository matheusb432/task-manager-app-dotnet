namespace TaskManagerApp.Application.Dtos.Goal
{
    public sealed class GoalDto
    {
        public GoalDto()
        {
            GoalSteps = new();
            GoalTaskItems = new();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        // TODO Active is true if all GoalSteps are finished
        public bool Active { get; set; }
        public List<GoalStepDto> GoalSteps { get; set; }
        public List<GoalTaskItemDto> GoalTaskItems { get; set; }
    }
}