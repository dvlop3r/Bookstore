namespace Bookstore.Contracts.Models;
public record BookstoreResponse(
    Guid Id,
    string Title,
    string Author,
    string Description,
    string CoverImageUrl,
    string BookUrl,
    DateTime PublishDate);