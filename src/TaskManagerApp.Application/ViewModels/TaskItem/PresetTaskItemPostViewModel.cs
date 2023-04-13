namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public sealed class PresetTaskItemPostViewModel
    {
        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public int UserId { get; set; }
    }
}