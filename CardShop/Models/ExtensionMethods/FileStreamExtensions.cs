using Microsoft.AspNetCore.Hosting;

namespace CardShop.Models.ExtensionMethods
{
    public static class FileStreamExtensions
    {
        public static void UploadImage(IFormFile file, IWebHostEnvironment hostEnvironment) 
        {
            string uploadDir = Path.Combine(hostEnvironment.WebRootPath, "images");
            string fileName = file.FileName;
            string filePath = Path.Combine(uploadDir, fileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
    }
}
