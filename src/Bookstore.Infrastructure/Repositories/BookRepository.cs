using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories;

public class BookRepository : Repository<Book> , IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Book?> getBookByIdAsync(Guid Id)
    {
        var book = await TableNoTracking.FirstOrDefaultAsync(x => x.Id == Id);
        return book;
    }
    public async Task<Book> addBookAsync(Book book)
    {
        return await InsertAsync(book);
    }
}