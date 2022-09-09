namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public string BookUrl { get; set; } = null!;
        public DateTime PublishDate { get; set; }
    }
}