using Bookstore.Client.Models;
using Bookstore.Client.Services;
using Bookstore.Client.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Bookstore.Client;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<AppSettings> _settings;

    public BookService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    private string? _baseUrl;
    private string BaseUrl => _baseUrl ?? (_baseUrl = _settings.Value.Services.ApiUrl);

    public async Task<IEnumerable<BookViewModel>> GetBooksAsync()
    {
        var response = _httpClient.GetAsync(BaseUrl).Result;
        var books = await response.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>();

        return books ?? new List<BookViewModel>();
    }
    public Task<BookViewModel> GetBookAsync(Guid id)
    {
        _baseUrl += "bookstore";
        throw new NotImplementedException();
    }
    public async Task<bool> CreateBookAsync(BookViewModel book)
    {
        _baseUrl += "bookstore";
        var content = GetHttpContent(book);
        var response = await _httpClient.PostAsync(_baseUrl, content);

        return response.IsSuccessStatusCode;
    }
    public Task UpdateBookAsync(BookViewModel book)
    {
        throw new NotImplementedException();
    }
    public Task DeleteBookAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    private HttpContent GetHttpContent(object obj)
    {
        var content = JsonConvert.SerializeObject(obj);

        var buffer = System.Text.Encoding.UTF8.GetBytes(content);

        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return byteContent;
    }
}