namespace Bookstore.Client.Models;
public record BookStoreRequest(
    string Title,
    string Author,
    string Description,
    string CoverImageUrl,
    string BookUrl,
    DateTime PublishDate);