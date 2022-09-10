using System.Net;

namespace Bookstore.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Book not found";
    public IEnumerable<string>? Errors { get; }
    public NotFoundException()
    {
        
    }
    public NotFoundException(string message) : base(message)
    {
    }
    public NotFoundException(string message, IEnumerable<string> Errors) : base(message)
    {
        this.Errors = Errors;
    }
    }
}