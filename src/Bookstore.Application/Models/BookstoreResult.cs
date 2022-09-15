namespace Bookstore.Application.Models;
    public record BookstoreResult(
        Guid Id,
        string Title,
        string Author,
        string Description,
        string CoverImageUrl,
        string BookUrl,
        DateTime PublishDate,
        DateTime Updated,
        DateTime Created);