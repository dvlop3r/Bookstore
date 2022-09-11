using Bookstore.Client.Models;
using Bookstore.Client.Services;
using Microsoft.Extensions.Options;

namespace Bookstore.Client;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;
    // private readonly IOptions<AppSettings> _appSettings;
    private string _baseUrl = "https://localhost:7257/api/";

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<BookViewModel>> GetBooksAsync()
    {
        _baseUrl += "bookstore";
        var response = _httpClient.GetAsync(_baseUrl).Result;
        if (response.IsSuccessStatusCode)
        {
            var books = response.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>().Result;
            return await Task.FromResult(books);
        }
        throw new NotImplementedException();
    }
    public Task<BookViewModel> GetBookAsync(Guid id)
    {
        _baseUrl += "bookstore";
        throw new NotImplementedException();
    }
    public Task CreateBookAsync(BookViewModel book)
    {
        throw new NotImplementedException();
    }
    public Task UpdateBookAsync(BookViewModel book)
    {
        throw new NotImplementedException();
    }
    public Task DeleteBookAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}