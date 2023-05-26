namespace TaskManagerApp.Application.Common.Dtos.Goal
{
    public sealed class GoalPutDto
    {
        public GoalPutDto()
        {
            GoalSteps = new();
            GoalTaskItems = new();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<GoalStepPutDto> GoalSteps { get; set; }
        public List<GoalTaskItemPutDto> GoalTaskItems { get; set; }
    }
}
