namespace Bookstore.Client.Models
{
    public class ProblemJson
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        
        public ProblemJsonErrors Errors { get; set; }
    }
}
