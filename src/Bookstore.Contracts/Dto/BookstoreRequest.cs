namespace Bookstore.Contracts.Models;
public record BookstoreRequest(
    string title,
    string author,
    string description,
    string coverImageUrl,
    string bookUrl,
    DateTime publishDate);