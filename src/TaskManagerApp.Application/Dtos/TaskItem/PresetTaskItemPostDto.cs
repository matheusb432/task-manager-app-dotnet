namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class PresetTaskItemPostDto
    {
        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
    }
}