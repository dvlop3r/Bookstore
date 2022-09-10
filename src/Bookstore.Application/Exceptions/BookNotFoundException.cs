using System.Net;

namespace Bookstore.Application.Exceptions;

public class BookNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErrorMessage => "Duplicate Book";
    public IEnumerable<string>? Errors { get; }
    public BookNotFoundException()
    {
        
    }
    public BookNotFoundException(string message) : base(message)
    {
    }
    public BookNotFoundException(string message, IEnumerable<string> Errors) : base(message)
    {
        this.Errors = Errors;
    }
}