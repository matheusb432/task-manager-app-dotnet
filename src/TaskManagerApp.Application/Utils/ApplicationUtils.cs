using Microsoft.AspNetCore.Http;

namespace TaskManagerApp.Application.Utils
{
    public static class ApplicationUtils
    {
        public static string ConvertImageToBase64(IFormFile image)
        {
            using var memoryStream = new MemoryStream();

            image.CopyTo(memoryStream);

            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
}
