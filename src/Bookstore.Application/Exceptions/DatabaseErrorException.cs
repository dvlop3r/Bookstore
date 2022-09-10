using System.Net;

namespace Bookstore.Application.Exceptions;

public class DatabaseErrorException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Database Book";
    public IEnumerable<string>? Errors { get; }
    public DatabaseErrorException()
    {
        
    }
    public DatabaseErrorException(string message) : base(message)
    {
    }
    public DatabaseErrorException(string message, IEnumerable<string> Errors) : base(message)
    {
        this.Errors = Errors;
    }
}