using Bookstore.Domain.Entities;

namespace Bookstore.Application.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<Book?> getUserByEmailAsync(string email);
    Task<Book> addUserAsync(Book book);
}