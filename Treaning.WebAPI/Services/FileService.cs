using Treaning.WebAPI.Helpers;
using Treaning.WebAPI.Interfaces.Services;

namespace Treaning.WebAPI.Services
{
    public class FileService : IFileService
    {
        private readonly string _basePath = String.Empty;
        private readonly string _imagesFolderName = "images";
        public FileService(IWebHostEnvironment env)
        {
            _basePath = env.WebRootPath;
        }
        public async Task<string> SaveImageAsync(IFormFile image)
        {
            string fileName = ImageHelper.MakeImageName(image.FileName);
            string partPath = Path.Combine(_imagesFolderName, fileName);
            string path = Path.Combine(_basePath, partPath);
            await image.CopyToAsync(new FileStream(path, FileMode.Create));
            return partPath;
        }
    }
}
