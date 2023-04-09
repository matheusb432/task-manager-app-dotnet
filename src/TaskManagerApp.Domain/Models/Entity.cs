namespace TaskManagerApp.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        // TODO - Update via context
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
    }
}
