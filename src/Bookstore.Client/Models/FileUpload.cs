namespace Bookstore.Client.Models
{
    public class FileUpload
    {
        public IFormFile? CoverImageFile{ get; set; }
        public IFormFile? BookFile { get; set; }
    }
}
