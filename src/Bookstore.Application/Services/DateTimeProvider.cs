using Bookstore.Application.Interfaces;

namespace Bookstore.Application.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
