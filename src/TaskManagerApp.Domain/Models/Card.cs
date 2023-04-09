namespace TaskManagerApp.Domain.Models
{
    public sealed class Card : Entity
    {
        public int PhotoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Status { get; set; }
        public Photo? Photo { get; set; }

        public static Card None() => new();
    }
}
