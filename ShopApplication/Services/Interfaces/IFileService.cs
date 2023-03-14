namespace ShopApplication.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> CreateFileAsync(IFormFile formFile);
        void DeleteFile(string fileName);
        Task<string> UpdateFileAsync(string oldFile,IFormFile newFormFile);
    }
}
