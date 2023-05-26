namespace TaskManagerApp.Application.Common.Dtos.Goal
{
    public sealed class GoalStepDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Finished { get; set; }
        public int GoalId { get; set; }
    }
}
