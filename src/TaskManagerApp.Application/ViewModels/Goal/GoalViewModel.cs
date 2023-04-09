namespace TaskManagerApp.Application.ViewModels.Goal
{
    public class GoalViewModel
    {
        public GoalViewModel()
        {
            GoalSteps = new();
            GoalTaskItems = new();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        // TODO Active is true if all GoalSteps are finished
        public bool Active { get; set; }
        public List<GoalStepViewModel> GoalSteps { get; set; }
        public List<GoalTaskItemViewModel> GoalTaskItems { get; set; }
    }
}