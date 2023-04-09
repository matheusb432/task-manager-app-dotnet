namespace TaskManagerApp.Domain.Models
{
    public class PresetTaskItem : Entity
    {
        public string Title { get; set; } = string.Empty;
        public short? Hours { get; set; }
        public int? ProfileId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public Profile? Profile { get; set; }
    }
}