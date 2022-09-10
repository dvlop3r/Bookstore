using System.Net;

namespace Bookstore.Application.Exceptions;

public class DuplicateBookException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Duplicate Book";
    public IEnumerable<string>? Errors { get; }
    public DuplicateBookException()
    {
        
    }
    public DuplicateBookException(string message) : base(message)
    {
    }
    public DuplicateBookException(string message, IEnumerable<string> Errors) : base(message)
    {
        this.Errors = Errors;
    }
}