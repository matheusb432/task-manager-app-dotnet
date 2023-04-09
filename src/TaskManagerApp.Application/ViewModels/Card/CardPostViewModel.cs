namespace TaskManagerApp.Application.ViewModels.Card
{
    public sealed class CardPostViewModel
    {
        public int PhotoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
