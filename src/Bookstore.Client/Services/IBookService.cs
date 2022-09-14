using Bookstore.Client.Models;

namespace Bookstore.Client.Services;
public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetBooksAsync();
    Task<BookViewModel> GetBookAsync(Guid id);
    Task<bool> CreateBookAsync(BookStoreRequest book);
    Task UpdateBookAsync(BookViewModel book);
    Task DeleteBookAsync(Guid id);
}
