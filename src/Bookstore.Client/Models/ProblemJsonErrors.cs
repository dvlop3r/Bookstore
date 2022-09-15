namespace Bookstore.Client.Models
{
    public class ProblemJsonErrors
    {
        public IEnumerable<string> Title { get; set; }
        public IEnumerable<string> Author { get; set; }
        public IEnumerable<string> Description { get; set; }
        public IEnumerable<string> PublishDate { get; set; }
        public IEnumerable<string> CoverImageUrl { get; set; }
        public IEnumerable<string> BookUrl { get; set; }

    }
}
