using Bookstore.Client.Models;

namespace Bookstore.Client.Services;
public interface IBookService
{
    Task<BookViewModel> GetBookAsync(Guid id);
    Task CreateBookAsync(BookViewModel book);
    Task UpdateBookAsync(BookViewModel book);
    Task DeleteBookAsync(Guid id);
}
