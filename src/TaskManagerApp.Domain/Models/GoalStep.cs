namespace TaskManagerApp.Domain.Models
{
    public class GoalStep : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Finished { get; set; }
        public int GoalId { get; set; }
        public Goal? Goal { get; set; }
    }
}