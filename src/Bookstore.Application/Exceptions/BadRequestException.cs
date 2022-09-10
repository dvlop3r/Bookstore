using System.Net;

namespace Bookstore.Application.Exceptions
{
    public class BadRequestException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public string ErrorMessage => "Bad Request";
        public IEnumerable<string>? Errors { get; }
        public BadRequestException()
        {
            
        }
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(string message, IEnumerable<string> Errors) : base(message)
        {
            this.Errors = Errors;
        }
    }
}