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

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<BookViewModel>> GetAllAsync(string baseUrl)
    {
        var response = _httpClient.GetAsync(baseUrl).Result;
        var books = await response.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>();

        return books ?? new List<BookViewModel>();
    }
    public async Task<BookViewModel?> GetAsync(Guid id, string baseUrl)
    {
        var response = _httpClient.GetAsync($"{baseUrl}/{id}").Result;
        var book = await response.Content.ReadFromJsonAsync<BookViewModel>();
        return book;
    }
    public async Task<(R?,E?)> CreateAsync<T, R, E>(string uri, T model)
    {
        var response = await _httpClient.PostAsJsonAsync(uri, model);
        if (response.IsSuccessStatusCode)
        {
            var book = await response.Content.ReadFromJsonAsync<R>();
            return (book, default);
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<E>();
            return (default, error);
        }
    }
    public Task UpdateAsync(BookViewModel book)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(Guid id)
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