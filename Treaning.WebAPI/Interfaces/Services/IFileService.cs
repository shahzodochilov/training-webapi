namespace Treaning.WebAPI.Interfaces.Services
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile image);
    }
}
