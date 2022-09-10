namespace Bookstore.Contracts.Models;
public record BookstoreResponse(
    string title,
    string author,
    string description,
    string coverImageUrl,
    string bookUrl,
    DateTime publishDate);