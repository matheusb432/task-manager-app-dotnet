namespace TaskManagerApp.Application.ViewModels.Goal
{
    public class GoalStepPostViewModel
    {
        public int GoalId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Finished { get; set; }
    }
}