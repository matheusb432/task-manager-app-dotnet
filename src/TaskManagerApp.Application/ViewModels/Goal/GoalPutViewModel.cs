namespace TaskManagerApp.Application.ViewModels.Goal
{
    public sealed class GoalPutViewModel
    {
        public GoalPutViewModel()
        {
            GoalSteps = new();
            GoalTaskItems = new();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<GoalStepPutViewModel> GoalSteps { get; set; }
        public List<GoalTaskItemPutViewModel> GoalTaskItems { get; set; }
    }
}