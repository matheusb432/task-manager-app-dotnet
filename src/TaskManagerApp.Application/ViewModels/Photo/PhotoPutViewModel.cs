namespace TaskManagerApp.Application.ViewModels.Photo
{
    public sealed class PhotoPutViewModel
    {
        public int Id { get; set; }
        public string Base64 { get; set; } = string.Empty;
    }
}