namespace TaskManagerApp.Application.Dtos.Goal
{
    public sealed class GoalStepPostDto
    {
        public int GoalId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Finished { get; set; }
    }
}