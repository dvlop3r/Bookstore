using Bookstore.Client.Models;

namespace Bookstore.Client.Services;
public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAllAsync(string url);
    Task<BookViewModel?> GetAsync(Guid id, string url);
    Task<(R, E)> CreateAsync<T,R,E>(string uri, T model);
    Task UpdateAsync(BookViewModel book);
    Task DeleteAsync(Guid id);
}
