using Bookstore.Client.Models;

namespace Bookstore.Client.Services
{
    public interface IFileStorageService
    {
        Task SaveFilesAsync(BookViewModel model, BookStoreResponse response);
        Task DownloadFileAsync(BookViewModel model);
    }
}
