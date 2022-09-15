namespace Bookstore.Client.Services
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(string fileName, Stream fileStream);
    }
}
