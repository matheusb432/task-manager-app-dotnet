namespace TaskManagerApp.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? UserCreatedId { get; set; }
        public int? UserUpdatedId { get; set; }
        public User? UserCreated { get; set; }
        public User? UserUpdated { get; set; }
    }
}