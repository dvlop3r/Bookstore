namespace Bookstore.Client.Models;
public record BookStoreRequest(
    string Title,
    string Author,
    string Description,
    DateTime PublishDate);