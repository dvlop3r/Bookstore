namespace Bookstore.Application.Interfaces;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}