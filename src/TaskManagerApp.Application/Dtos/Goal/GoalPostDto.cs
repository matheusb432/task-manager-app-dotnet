namespace TaskManagerApp.Application.Dtos.Goal
{
    public sealed class GoalPostDto
    {
        public GoalPostDto()
        {
            GoalSteps = new();
        }

        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<GoalStepPostDto> GoalSteps { get; set; }
    }
}
