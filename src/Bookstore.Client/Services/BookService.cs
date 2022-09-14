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

    public async Task<IEnumerable<BookViewModel>> GetBooksAsync(string baseUrl)
    {
        var response = _httpClient.GetAsync(baseUrl).Result;
        var books = await response.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>();

        return books ?? new List<BookViewModel>();
    }
    public async Task<BookViewModel?> GetBookAsync(Guid id, string baseUrl)
    {
        var response = _httpClient.GetAsync($"{baseUrl}/{id}").Result;
        BookViewModel? book = await response.Content.ReadFromJsonAsync<BookViewModel>();
        return book;
    }
    public async Task<R> CreateBookAsync<T,R>(string uri, T model)
    {
        var response = await _httpClient.PostAsJsonAsync(uri, model);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var httpResponse = JsonConvert.DeserializeObject<BookHttpResponse<R>>(responseString);

        if(httpResponse.HasError)
            throw new Exception(httpResponse.Message ?? "Unknown error occured");
        return httpResponse.Data;
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