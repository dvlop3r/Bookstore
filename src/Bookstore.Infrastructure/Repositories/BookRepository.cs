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

    public async Task<Book?> getUserByEmailAsync(string email)
    {
        var user = await TableNoTracking.FirstOrDefaultAsync(x => x.Description == email);
        return user;
    }
    public async Task<Book> addUserAsync(Book book)
    {
        return await InsertAsync(book);
    }
}