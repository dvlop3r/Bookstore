using Bookstore.Domain.Entities;

namespace Bookstore.Application.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<Book?> getBookByIdAsync(Guid Id);
    Task<Book> addBookAsync(Book book);
}