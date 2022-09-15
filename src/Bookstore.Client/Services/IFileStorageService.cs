using Bookstore.Client.Models;

namespace Bookstore.Client.Services
{
    public interface IFileStorageService
    {
        Task SaveFileAsync(BookViewModel model);
    }
}
