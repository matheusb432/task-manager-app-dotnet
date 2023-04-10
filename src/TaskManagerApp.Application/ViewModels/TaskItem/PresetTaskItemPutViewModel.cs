namespace TaskManagerApp.Application.ViewModels.TaskItem
{
    public sealed class PresetTaskItemPutViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public short? Hours { get; set; }
        public int UserId { get; set; }
    }
}