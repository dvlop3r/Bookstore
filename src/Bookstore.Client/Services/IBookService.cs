using Bookstore.Client.Models;

namespace Bookstore.Client.Services;
public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAllAsync(string url);
    Task<BookViewModel?> GetAsync(Guid id, string url);
    Task<(R?, E?)> CreateAsync<T,R,E>(string uri, T model);
    Task<(T?,E?)> UpdateAsync<T,E>(string uri, T model, Guid id);
    Task DeleteAsync(Guid id);
}
