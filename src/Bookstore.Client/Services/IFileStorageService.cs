using Bookstore.Client.Models;

namespace Bookstore.Client.Services
{
    public interface IFileStorageService
    {
        Task SaveFilesAsync(BookViewModel model, BookStoreResponse response);
        Task<(byte[], string, string)> DownloadFileAsync(Guid id, string file);
        Task<string> GetBookPathAsync(Guid book);
    }
}
