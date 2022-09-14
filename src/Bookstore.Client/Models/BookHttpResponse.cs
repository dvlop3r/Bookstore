namespace Bookstore.Client.Models
{
    public class BookHttpResponse<T>
    {
        public bool HasError { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
