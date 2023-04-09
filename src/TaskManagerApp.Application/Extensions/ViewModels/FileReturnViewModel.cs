namespace TaskManagerApp.Application.Extensions.ViewModels
{
    public sealed class FileReturnViewModel
    {
        public byte[] Content { get; set; } = Array.Empty<byte>();

        public string MimeType { get; set; } = string.Empty;

        private FileReturnViewModel()
        {
        }

        private static FileReturnViewModel FromFileBytes(byte[] content, string mimeType)
            => new()
            {
                Content = content,
                MimeType = mimeType
            };

        public static FileReturnViewModel FromImageBytes(byte[] content, string fileName = "image.png")
            => FromFileBytes(content, "image/png");
    }
}