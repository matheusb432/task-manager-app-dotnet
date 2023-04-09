namespace TaskManagerApp.Domain.Models
{
    public sealed class Photo : Entity
    {
        public string Base64 { get; set; } = string.Empty;
        public Card? Card { get; set; }

        public static Photo None() => new();

        public static Photo FromBase64(string base64) => new() { Base64 = base64 };
    }
}
