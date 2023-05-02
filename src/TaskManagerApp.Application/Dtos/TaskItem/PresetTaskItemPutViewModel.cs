namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class PresetTaskItemPutDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public short? Time { get; set; }
        public int UserId { get; set; }
    }
}