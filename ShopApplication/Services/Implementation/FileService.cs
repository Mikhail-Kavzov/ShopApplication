using ShopApplication.Common;
using ShopApplication.Services.Interfaces;

namespace ShopApplication.Services.Implementation
{
    public class FileService : IFileService
    {
        private static readonly string _fileFolder = "images/";
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void CreateFile(string fileName)
        {
            File.Create(Path.Combine(_fileFolder, fileName));
        }

        public async Task<string> CreateFileAsync(IFormFile formFile)
        {
            var path = MyGuid.GetGuid() + formFile.FileName;
            using var fileStream = new FileStream
                (Path.Combine(_webHostEnvironment.WebRootPath, _fileFolder, path),
                FileMode.Create);
            await formFile.CopyToAsync(fileStream);
            return path;
        }

        public void DeleteFile(string fileName)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, _fileFolder, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public async Task<string> UpdateFileAsync(string oldFile, IFormFile newFormFile)
        {
            DeleteFile(oldFile);
            return await CreateFileAsync(newFormFile);
        }
    }
}
