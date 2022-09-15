namespace Bookstore.Contracts.Models;
public record BookstoreRequest(
    string Title,
    string Author,
    string Description,
    string? CoverImageUrl,
    string? BookUrl,
    DateTime PublishDate);