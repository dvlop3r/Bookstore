using Bookstore.Client.Models;

namespace Bookstore.Client.Services;
public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetBooksAsync(string url);
    Task<BookViewModel?> GetBookAsync(Guid id, string url);
    Task<R> CreateBookAsync<T,R>(string uri, T model);
    Task UpdateBookAsync(BookViewModel book);
    Task DeleteBookAsync(Guid id);
}
