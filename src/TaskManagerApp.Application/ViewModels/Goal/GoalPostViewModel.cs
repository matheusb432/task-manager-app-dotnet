namespace TaskManagerApp.Application.ViewModels.Goal
{
    public class GoalPostViewModel
    {
        public GoalPostViewModel()
        {
            GoalSteps = new();
        }

        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<GoalStepPostViewModel> GoalSteps { get; set; }
    }
}