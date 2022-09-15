namespace Bookstore.Client.Models;
public record BookStoreResponse(
    Guid Id,
    string Title,
    string Author,
    string Description,
    string CoverImageUrl,
    string BookUrl,
    DateTime PublishDate);