namespace Bookstore.Client.Models;

public class BookViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Author { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? BookUrl { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}