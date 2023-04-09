namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public class PresetTaskItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public short? Hours { get; set; }
        public int UserId { get; set; }
    }
}