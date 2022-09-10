using System.Net;

namespace Bookstore.Application.Exceptions
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
        public IEnumerable<string>? Errors { get;}
    }
}